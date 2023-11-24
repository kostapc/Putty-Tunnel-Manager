/**
 * Copyright (c) 2009, Joeri Bekker
 * 
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 * 
 * The above copyright notice and this permission notice shall be included in
 * all copies or substantial portions of the Software.
 * 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
 * THE SOFTWARE.
 */
using System.Diagnostics;
using System.Text;

using JoeriBekker.PuttyTunnelManager.Forms;

namespace JoeriBekker.PuttyTunnelManager
{
    class PuttyLink
    {
        private Session session;
        private Process process;
        private bool active;
        private bool restart = true;
        private bool killing = false;

        public PuttyLink(Session session)
        {
            this.session = session;

            this.process = new Process();
            this.process.StartInfo.FileName = PuttyTunnelManagerSettings.Instance().PlinkLocation;
            this.process.StartInfo.CreateNoWindow = true;
            this.process.StartInfo.UseShellExecute = false;            

            this.active = false;
        }

        private Thread createGuardian()
        {
            Thread guardian = new Thread(Guardian);
            guardian.IsBackground = true;
            guardian.Priority = ThreadPriority.Lowest;
            return guardian;
        }

        public Session Session => this.session;
        public bool IsActive => this.active;
        public void Start() => this.Start(true);       

        public void Start(bool interactive)
        {
            if (!PuttyTunnelManagerSettings.Instance().HasPlink)
            {
                throw new PlinkNotFoundException();
            }
            restart = true;
            this.active = true;

            Session.OpenSessions.Add(this.session);            

            if (interactive)
            {
                this.process.StartInfo.RedirectStandardOutput = true;
                this.process.StartInfo.RedirectStandardInput = true;
            }

            StringBuilder args = new StringBuilder("-agent -N -load \"" + this.session.Name + "\"");
            if (this.session.UsePtmForTunnels)
            {
                foreach (Tunnel tunnel in this.session.Tunnels)
                {
                    switch (tunnel.Type)
                    {
                        case TunnelType.LOCAL:
                            args.Append(" -L " + tunnel.SourcePort + ":" + tunnel.Destination + ":" + tunnel.DestinationPort);
                            break;
                        case TunnelType.REMOTE:
                            args.Append(" -R " + tunnel.SourcePort + ":" + tunnel.Destination + ":" + tunnel.DestinationPort);
                            break;
                        case TunnelType.DYNAMIC:
                            args.Append(" -D " + tunnel.SourcePort);
                            break;
                    }
                }
            }

            this.process.StartInfo.Arguments = args.ToString();
            this.process.Start();
            createGuardian().Start();
            Debug.WriteLine("Plink: Started!");

            if (interactive)
            {
                this.process.StandardInput.AutoFlush = true;
                var plinkstart = true;
                StringBuilder buffer = new StringBuilder();
                string username = this.session.Username;
                while (!this.process.HasExited)
                {
                    while (this.process.StandardOutput.Peek() > 0)
                    {
                        char c = (char)this.process.StandardOutput.Read();
                        buffer.Append(c);
                    }

                    string data = buffer.ToString().ToLower();

                    if(plinkstart && data.Length==0 && !killing)
                    {
                        // TODO: automatic accept new cert at first connection
                        // trying to pass and see if process exists.
                        throw new CurruptedSessionException();
                    }

                    if (data.Contains("login"))
                    {
                        LoginForm form = new LoginForm();
                        if (form.ShowDialog() == DialogResult.OK)
                        {
                            username = form.Username;
                            if (form.SaveUsername)
                            {
                                session.Username = username;
                                session.Serialize();
                            }
                            this.process.StandardInput.WriteLine(username);
                        }
                        else
                        {
                            Stop();
                        }
                    }
                    else if (data.Contains("password"))
                    {
                        if(session.Password==null)
                        {
                            LoginForm form = new LoginForm(username);
                            if (form.ShowDialog() == DialogResult.OK)
                            {
                                session.Password = form.Password;                                
                            }
                        }
                        if(session.Password==null)
                        {
                            Stop();
                        }
                        this.process.StandardInput.WriteLine(session.Password);
                        plinkstart = false;                    
                    }
                    this.process.StandardOutput.DiscardBufferedData();
                    buffer.Remove(0, buffer.Length);
                }
                Debug.WriteLine("Interactive session closed: process finished");
            }
            else
            {
                this.process.WaitForExit();
                Debug.WriteLine("non-Interactive session closed: process finished");
            }

            Debug.WriteLine("Plink: Stopped!");
            Session.OpenSessions.Remove(this.session);
            this.active = false;
        }

        public void Stop()
        {
            restart = false;
            killing = true;
            Debug.WriteLine("Plink: Terminating!");
            closeProccess();
        }

        private void Guardian()
        {
            Debug.WriteLine("Plink: Starting Guardian!");
            
            try
            {
                do
                {
                    Thread.Sleep(500);
                    if (this.process.HasExited)
                    {
                        Debug.WriteLine("Guardian: Stopped due to Plink termination!");
                        return;                                                                   
                    }                                  
                    //Debug.WriteLine("Guardian: Plink is alive!");

                } while (this.process.Responding);
                Debug.WriteLine("Guardian: Plink stopped responding!");
            }
            catch (Exception e)
            {
                Debug.WriteLine("Guardian: Exception! "+e.Message);
                Debug.WriteLine(e.StackTrace);
            }
            finally
            {
                if (!this.process.HasExited)
                {
                    closeProccess();
                }
                Debug.WriteLine("Guardian: plink died. restart = "+restart);
                if(restart)
                {
                    // restart process and Guardian
                    // show notification near system tray
                    // issue #18

                    UserNotifications.Notify(this.session.Name, "terminated! Reconnecting...");

                    AsyncRestartPlink();

                    UserNotifications.Notify(this.session.Name, "terminated! Reconnecting... Done!");

                }
            }
            Debug.WriteLine("Guardian: Stopped!");
        }

        private void AsyncRestartPlink()
        {
            
            Thread runner = new Thread(() => {
                Debug.WriteLine("restarting plink process...");
                this.Start(true);
                Thread.Sleep(80);
            });
            runner.IsBackground = true;
            runner.Priority = ThreadPriority.Lowest;
            runner.Start();            
            runner.Join();            
        }

        private void closeProccess()
        {
            try
            {
                this.process.Kill();
                Debug.WriteLine("Plink: Killed!");
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }
        }
    }
       
}

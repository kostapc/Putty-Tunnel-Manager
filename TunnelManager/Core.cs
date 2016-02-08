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
using System.Collections.Generic;

namespace JoeriBekker.PuttyTunnelManager
{
    class Core
    {
        private static Core instance = null;

        public static Session EmptySession = new EmptySession();

        public static Core Instance()
        {
            if (Core.instance == null)
                Core.instance = new Core();

            return Core.instance;
        }

        private List<Session> sessions;

        private Core()
        {
            this.sessions = new List<Session>();

            Initialize();
        }

        public void Refresh()
        {
            this.sessions.Clear();

            Initialize();
        }

        private void Initialize()
        {
            foreach (string sessionName in PuttySettings.Instance().Sessions)
            {
                this.sessions.Add(Session.Load(sessionName));
            }
        }

        public List<Session> Sessions
        {
            get { return this.sessions; }
        }

        public List<Tunnel> Tunnels
        {
            get
            {
                List<Tunnel> tunnels = new List<Tunnel>();
                foreach (Session session in this.Sessions)
                {
                    foreach (Tunnel tunnel in session.Tunnels)
                    {
                        tunnels.Add(tunnel);
                    }
                }
                return tunnels;
            }
        }
    }
}

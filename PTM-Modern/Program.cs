using JoeriBekker.PuttyTunnelManager;
using JoeriBekker.PuttyTunnelManager.Forms;
using System.Reflection;

namespace PTM_Modern
{
    internal static class Program
    {
        public static Logging Log = Loggers.WINLOG;

        public static TrayIcon TrayIcon;

        private static Mutex mutex;

        private static bool IsAlreadyRunning()
        {
            string strLoc = Assembly.GetExecutingAssembly().Location;
            FileSystemInfo fileInfo = new FileInfo(strLoc);
            string exeName = fileInfo.Name;

            mutex = new Mutex(true, "Global\\" + exeName, out bool createdNew);
            if (createdNew)
            {
                mutex.ReleaseMutex();
            }

            return !createdNew;
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main()
        {
            //Log.WriteMessage("PTM starting");
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(ErrosHandler);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (IsAlreadyRunning())
            {
                MessageBox.Show("An instance of " + Application.ProductName + " is already running.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            TrayIcon = new TrayIcon();

            Application.Run();
            TrayIcon = null;
        }

        static void ErrosHandler(object sender, UnhandledExceptionEventArgs args)
        {
            //Log.WriteError(args.ExceptionObject, "unhandled error from " + sender.ToString());
        }
    }
}
using System;
using System.Diagnostics;
using System.Security;

namespace JoeriBekker.PuttyTunnelManager
{
    public class Logging
    {

        public string Source { get; set; }

        public Logging()
        {
            Source = CreateEventSource(AppDomain.CurrentDomain.FriendlyName);
        }

        public void WriteMessage(String message)
        {
            EventLog.WriteEntry(Source, message);
        }

        public void WriteError(Exception ex, String message)
        {
            var logMessage = message + "\n" + ex.ToString();
            EventLog.WriteEntry(Source, logMessage, EventLogEntryType.Error);
        }

        public void WriteError(object ex, String message)
        {
            var logMessage = message + "\n" + ex.ToString();
            EventLog.WriteEntry(Source, logMessage, EventLogEntryType.Error);
        }


        private string CreateEventSource(string currentAppName)
        {
            string eventSource = currentAppName;
            bool sourceExists;
            try
            {
                // searching the source throws a security exception ONLY if not exists!
                sourceExists = EventLog.SourceExists(eventSource);
                if (!sourceExists)
                {   // no exception until yet means the user as admin privilege
                    EventLog.CreateEventSource(eventSource, "Application");
                }
            }
            catch (SecurityException ex)
            {
                eventSource = "Application";
            }
            return eventSource;
        }

    }
}

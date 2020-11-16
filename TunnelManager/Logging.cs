using System;
using System.Diagnostics;
using System.Globalization;
using System.Security;

namespace JoeriBekker.PuttyTunnelManager
{
    public readonly struct Loggers
    {
        public static Logging WEL = new Logging();
    }

    public class Logging
    {        

        // https://www.jitbit.com/alexblog/266-writing-to-an-event-log-from-net-without-the-description-for-event-id-nonsense/
        // 
        private static readonly string SourceName = ".NET Runtime";
        private static readonly int SourceMessageId = 1000;

        private static readonly int MaxEventLogEntryLength = 30000;

        public string Source { get; set; }

        public Logging()
        {
            Source = CreateEventSource(AppDomain.CurrentDomain.FriendlyName);
        }

        public void WriteMessage(String message)
        {
            EventLog.WriteEntry(Source, EnsureLogMessageLimit(message), EventLogEntryType.Information, SourceMessageId);
        }

        public void WriteError(String message)
        {
            EventLog.WriteEntry(Source, EnsureLogMessageLimit(message), EventLogEntryType.Error, SourceMessageId);
        }

        public void WriteError(Exception ex, String message)
        {
            var logMessage = message + "\n" + ex.ToString();
            Debug.WriteLine(logMessage);
            WriteError(logMessage);
        }

        public void WriteError(object ex, String message)
        {
            var logMessage = message + "\n" + ex.ToString();
            WriteError(logMessage);
        }

        private static string EnsureLogMessageLimit(string logMessage)
        {
            if (logMessage.Length > MaxEventLogEntryLength)
            {
                string truncateWarningText = string.Format(
                    CultureInfo.CurrentCulture, 
                    "... | Log Message Truncated [ Limit: {0} ]", 
                    MaxEventLogEntryLength
                );
                
                logMessage = logMessage.Substring(0, MaxEventLogEntryLength - truncateWarningText.Length);

                logMessage = string.Format(CultureInfo.CurrentCulture, "{0}{1}", logMessage, truncateWarningText);
            }

            return logMessage;
        }

        private static string CreateEventSource(string currentAppName)
        {
            string eventSource = currentAppName;
            bool sourceExists;
            try
            {
                // searching the source throws a security exception ONLY if not exists!
                sourceExists = EventLog.SourceExists(eventSource);
                if (!sourceExists)
                {   // no exception until yet means the user as admin privilege
                    EventLog.CreateEventSource(eventSource, SourceName);
                }
            }
            catch (SecurityException ex)
            {
                Debug.WriteLine("logging source problem: " + ex.ToString());
                eventSource = SourceName;
            }
            return eventSource;
        }

    }
}

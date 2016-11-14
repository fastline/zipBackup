using System;
using System.Diagnostics;

namespace zipBackup
{
    public static class Logger
    {
        public static void createLogSource()
        {
            if (!EventLog.SourceExists("zipBackup"))
            {
                EventLog.CreateEventSource("zipBackup", "Apllication");
            }
        }
        public static void writeEventLog(string _logMessage, string _logSource)
        {
            EventLogEntryType _logSeverity = EventLogEntryType.Error;
            EventLog.WriteEntry(_logSource, _logMessage, _logSeverity, 125);
        }
    }
}

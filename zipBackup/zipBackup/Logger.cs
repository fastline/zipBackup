using System;
using System.Diagnostics;

namespace zipBackup
{
    public static class Logger
    {
        public static void writeEventLog(string _logMessage)
        {
            string _logSource = "zipBackup";
            EventLogEntryType _logSeverity = EventLogEntryType.Error;

            EventLog.WriteEntry(_logSource, _logMessage, _logSeverity, 125);
        }

        public static void writeEventLog(string _logMessage, EventLogEntryType _logSeverity)
        {
            string _logSource = "zipBackup";

            EventLog.WriteEntry(_logSource, _logMessage, _logSeverity, 125);
        }
    }
}

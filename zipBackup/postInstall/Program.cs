using System;
using System.Diagnostics;

namespace postInstall
{
    class Program
    {
        static void Main(string[] args)
        {
            string logSource = "zipBackup";
            
            if (!EventLog.SourceExists(logSource))
            {
                EventLog.CreateEventSource(logSource, "Application");
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Führerschein
{
    internal static class clsEventLogInWindows
    {
        private static string SourceName = "Führerschein";

       public  enum enEventLogInformation  {Information = 0, Warning = 1, Error = 2}

        public static  void LogEvent(enEventLogInformation LogType, string message)
        {
            if(!EventLog.SourceExists(SourceName))
            {
                EventLog.CreateEventSource(SourceName, "Information");
            }

            switch(LogType)
            {
                case enEventLogInformation.Information:
                    EventLog.WriteEntry(SourceName, message, EventLogEntryType.Information);
                    break;

                case enEventLogInformation.Warning:
                    EventLog.WriteEntry(SourceName, message, EventLogEntryType.Warning);
                    break;

                case enEventLogInformation.Error:
                    EventLog.WriteEntry(SourceName, message, EventLogEntryType.Error);
                    break;

                default:
                    EventLog.WriteEntry(SourceName, message, EventLogEntryType.Information);
                    break;

            }
        }
        
    }
}

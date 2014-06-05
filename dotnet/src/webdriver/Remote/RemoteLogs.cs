using System;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium.Logging;

namespace OpenQA.Selenium.Remote
{
    internal class RemoteLogs : ILogs
    {
        private const string LevelKey = "level";
        private const string TimestampKey = "timestamp";
        private const string MessageKey = "message";
        private const string TypeKey = "type";

        private RemoteWebDriver driver;

        public RemoteLogs(RemoteWebDriver driver)
        {
            this.driver = driver;
        }

        public IEnumerable<LogEntry> Get(string logType)
        {
            var raw = driver.InternalExecute(DriverCommand.GetLog, new Dictionary<string, object> {{TypeKey, logType}});
            return ((List<Dictionary<string, object>>) raw.Value).Select(entry => new LogEntry(LogLevelMapping.ToLevel((string)entry[LevelKey]), (long) entry[TimestampKey], (string) entry[MessageKey]));
        }

        public HashSet<string> GetAvailableLogTypes()
        {
            var raw = driver.InternalExecute(DriverCommand.GetAvailableLogTypes, null);
            var stringLevels = (List<String>) raw.Value;
            return new HashSet<string>(stringLevels);
        }
    }
}
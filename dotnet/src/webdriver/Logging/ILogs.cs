using System;
using System.Collections.Generic;

namespace OpenQA.Selenium.Logging
{
    public interface ILogs
    {
        IEnumerable<LogEntry> Get(String logType);

        /// <summary>
        /// Queries for available log types.
        /// </summary>
        /// <returns>A set of available log types.</returns>
        HashSet<string> GetAvailableLogTypes();
    }
}
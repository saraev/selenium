using System;

namespace OpenQA.Selenium.Logging
{
    /// <summary>
    /// Convert string representation of logging level to Level enum
    /// </summary>
    public static class LogLevelMapping
    {
        /// <summary>
        /// Convert string representation of logging level to Level enum
        /// </summary>
        /// <param name="logLevelName">string representation of logging level</param>
        /// <returns>Corresponding logging level</returns>
        public static Level ToLevel(string logLevelName)
        {
            Level level;
            if (!Enum.TryParse(logLevelName, true, out level))
            {
                // Default the log level to info.
                return Level.Info;
            }
            return level;
        }
    }
}
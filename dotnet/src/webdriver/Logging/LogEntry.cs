using System;

namespace OpenQA.Selenium.Logging
{
    /// <summary>
    /// Represents a single log statement.
    /// </summary>
    public class LogEntry {
        public LogEntry(Level level, long timestamp, String message) {
            this.Level = level;
            this.Timestamp = timestamp;
            this.Message = message;
        }

        /// <summary>
        /// Logging entry's severity.
        /// </summary>
        public Level Level { get; private set; }

        /// <summary>
        /// Timestamp of the log statement in milliseconds since UNIX Epoch.
        /// </summary>
        public long Timestamp { get; private set; }

        /// <summary>
        /// Log entry's message.
        /// </summary>
        public string Message { get; private set; }

        public override string ToString() {
            return string.Format("{0} {1} {2}", new DateTime(Timestamp, DateTimeKind.Utc).ToString("s") + "Z", Level, Message);
        }
    }
}
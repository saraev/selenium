namespace OpenQA.Selenium.Logging
{
    /// <summary>
    /// Supported log types.
    /// </summary>
    public class LogType
    {
        /// <summary>
        /// This log type pertains to logs from the browser. 
        /// </summary>
        public const string Browser = "browser";

        /// <summary>
        /// This log type pertains to logs from the client.
        /// </summary>
        public const string Client = "client";

        /// <summary>
        /// This log pertains to logs from the WebDriver implementation.
        /// </summary>
        public const string Driver = "driver";

        /// <summary>
        /// This log type pertains to logs relating to performance timings.
        /// </summary>
        public const string Performance = "performance";

        /// <summary>
        /// This log type pertains to logs relating to performance timings.
        /// </summary>
        public const string Profiler = "profiler";

        /// <summary>
        /// This log type pertains to logs from the remote server.
        /// </summary>
        public const string Server = "server";
    }
}
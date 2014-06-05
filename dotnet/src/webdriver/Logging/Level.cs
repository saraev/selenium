namespace OpenQA.Selenium.Logging
{
    /// <summary>
    /// Log level names from WebDriver's JSON wire protocol.
    /// </summary>
    public enum Level
    {
        /// <summary>
        /// All log messages. Used for fetching of logs and configuration of logging.
        /// </summary>
        All = 0,

        /// <summary>
        /// Messages for debugging.
        /// </summary>
        Debug = 500,

        /// <summary>
        /// Messages with user information.
        /// </summary>
        Info = 800,

        /// <summary>
        /// Messages corresponding to non-critical problems.
        /// </summary>
        Warning = 900,

        /// <summary>
        /// Messages corresponding to critical errors.
        /// </summary>
        Severe = 1000,

        /// <summary>
        /// No log messages. Used for configuration of logging.
        /// </summary>
        Off = int.MaxValue,
    }
}
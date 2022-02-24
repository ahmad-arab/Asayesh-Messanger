
namespace AsayeshMessenger.Core
{
    /// <summary>
    ///The level of detail to output for a logger
    /// </summary>
    public enum LogOutputLevel
    {
        /// <summary>
        /// Logs everything
        /// </summary>
        Debug = 1,

        /// <summary>
        /// Log all information, except for debug information
        /// </summary>
        Verbose=2,

        /// <summary>
        /// Log all Informative messages, ignoring any debug and verbose messages
        /// </summary>
        Informative=3,

        /// <summary>
        /// Logs only critical warnings, errors and success , with no general information
        /// </summary>
        Critical = 4,

        /// <summary>
        /// The logger will never output anything
        /// </summary>
        Nothing = 5
    }
}

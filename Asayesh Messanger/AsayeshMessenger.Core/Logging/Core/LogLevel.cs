
namespace AsayeshMessenger.Core
{
    /// <summary>
    ///The severity of the log message
    /// </summary>
    public enum LogLevel
    {
        /// <summary>
        /// Developer-specific information
        /// </summary>
        Debug = 1,

        /// <summary>
        /// Verbose information
        /// </summary>
        Verbose=2,

        /// <summary>
        /// General information
        /// </summary>
        Informative=3,

        /// <summary>
        /// A warning
        /// </summary>
        Warning = 4,

        /// <summary>
        /// An Error
        /// </summary>
        Error = 5,

        /// <summary>
        /// A Success
        /// </summary>
        Success = 6,
    }
}

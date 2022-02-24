
using System;
using System.Runtime.CompilerServices;

namespace AsayeshMessenger.Core
{
    public interface ILogFactory
    {
        #region Events

        /// <summary>
        /// Fires whenever a new log arrives
        /// </summary>
        event Action<(string Message, LogLevel Level)> NewLog;

        #endregion

        #region Properties

        /// <summary>
        /// The level of the message to log
        /// </summary>
        LogOutputLevel LogOutputLevel { get; set; }

        /// <summary>
        /// If true, includes the file/line/member wich the log message was logged from
        /// </summary>
        bool IncludeLogOriginDetails { get; set; }
        #endregion

        #region Methods

        /// <summary>
        /// Adds a specific logger to the factory
        /// </summary>
        /// <param name="logger">The Logger</param>
        void AddLogger(ILogger logger);

        /// <summary>
        /// Removes a specific logger to the factory
        /// </summary>
        /// <param name="logger">The Logger</param>
        void RemoveLogger(ILogger logger);

        /// <summary>
        /// Logs the specified message to all loggers in this factory
        /// </summary>
        /// <param name="message">The message to be logged</param>
        /// <param name="level">The level of the message to be logged</param>
        /// <param name="origin">The method/function this message was logged in</param>
        /// <param name="filePath">The file wich this message was logged in</param>
        /// <param name="lineNumber">The line number wich this message was logged in</param>
        void Log(
            string message, 
            LogLevel level = LogLevel.Informative, 
            [CallerMemberName]string origin = "",
            [CallerFilePath]string filePath = "",
            [CallerLineNumber]int lineNumber = 0);
        #endregion
    }
}

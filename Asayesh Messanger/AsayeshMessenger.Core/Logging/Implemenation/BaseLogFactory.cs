
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;

namespace AsayeshMessenger.Core
{
    /// <summary>
    ///The standard log factory
    ///Logs details to debug, consol, trace and log files
    /// </summary>
    public class BaseLogFactory : ILogFactory
    {
        #region Protected Properties

        /// <summary>
        /// The list of loggers this factory have
        /// </summary>
        protected List<ILogger> mLoggers = new List<ILogger>();

        /// <summary>
        /// A Lock for the loggers list to keep it thread safe
        /// </summary>
        protected object mLoggersLock = new object();
        #endregion

        #region Public Properties

        /// <summary>
        /// The level of the message to log
        /// </summary>
        public LogOutputLevel LogOutputLevel { get; set; }

        /// <summary>
        /// If true, includes the file/line/member wich the log message was logged from
        /// </summary>
        public bool IncludeLogOriginDetails { get; set; } = true;

        #endregion

        #region Public Events

        /// <summary>
        /// Fires whenever a new log arrives
        /// </summary>
        public event Action<(string Message, LogLevel Level)> NewLog = (details) => { };

        #endregion

        #region Constructor

        public BaseLogFactory()
        {
            AddLogger(new ConsoleLogger());
        }

        #endregion

        #region Methods

        /// <summary>
        /// Adds a specific logger to the factory
        /// </summary>
        /// <param name="logger">The Logger</param>
        public void AddLogger(ILogger logger)
        {
            lock(mLoggersLock)
            {
                if (!mLoggers.Contains(logger))
                    mLoggers.Add(logger);
            }
        }

        /// <summary>
        /// Removes a specific logger to the factory
        /// </summary>
        /// <param name="logger">The Logger</param>
        public void RemoveLogger(ILogger logger)
        {
            lock (mLoggersLock)
            {
                if (mLoggers.Contains(logger))
                    mLoggers.Remove(logger);
            }
        }

        /// <summary>
        /// Logs the specified message to all loggers in this factory
        /// </summary>
        /// <param name="message">The message to be logged</param>
        /// <param name="level">The level of the message to be logged</param>
        /// <param name="origin">The method/function this message was logged in</param>
        /// <param name="filePath">The file wich this message was logged in</param>
        /// <param name="lineNumber">The line number wich this message was logged in</param>
        public void Log(
            string message, 
            LogLevel level = LogLevel.Informative, 
            [CallerMemberName]string origin = "", 
            [CallerFilePath]string filePath = "", 
            [CallerLineNumber]int lineNumber = 0)
        {
            if ((int)level < (int)LogOutputLevel)
                return;

            if (IncludeLogOriginDetails)
                message = $"[{Path.GetFileName(filePath)} > {origin}() > Line {lineNumber}]{Environment.NewLine}{message}";

            mLoggers.ForEach(logger => logger.Log(message, level));

            NewLog.Invoke((message, level));
        }
        #endregion
    }
}

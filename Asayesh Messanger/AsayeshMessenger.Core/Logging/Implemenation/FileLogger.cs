
using System;

namespace AsayeshMessenger.Core
{
    public class FileLogger: ILogger
    {
        #region Public Properties
        public string FilePath { get; set; }
        public bool LogTime { get; set; } = true;
        #endregion

        #region Constructor
        /// <summary>
        /// Default Constructor
        /// </summary>
        public FileLogger(string filePath)
        {
            FilePath = filePath;
        }
        #endregion

        #region Logger Methods
        public void Log(string message, LogLevel level)
        {
            string currentTime = DateTimeOffset.Now.ToString("yyyy-MM-dd hh-mm-ss tt");

            var timeLogString = LogTime ? $"[{currentTime}] " : "";
            IoC.File.WriteTextToFileAsync($"{timeLogString}{message}{Environment.NewLine}", FilePath, true);
        }
        #endregion
    }
}

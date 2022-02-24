
using System;

namespace AsayeshMessenger.Core
{
    /// <summary>
    ///Logs messages to the console
    /// </summary>
    public class ConsoleLogger : ILogger
    {
        /// <summary>
        /// Logs the message to the system console
        /// </summary>
        /// <param name="message">The message being logged</param>
        /// <param name="level">The level of the log message</param>
        public void Log(string message, LogLevel level)
        {
            var consoleOldColor = Console.ForegroundColor;
            var consoleColor = ConsoleColor.White;
            switch(level)
            {
                case LogLevel.Debug:
                    consoleColor = ConsoleColor.Blue;
                    break;
                case LogLevel.Verbose:
                    consoleColor = ConsoleColor.Gray;
                    break;
                case LogLevel.Warning:
                    consoleColor = ConsoleColor.DarkYellow;
                    break;
                case LogLevel.Error:
                    consoleColor = ConsoleColor.Red;
                    break;
                case LogLevel.Success:
                    consoleColor = ConsoleColor.Green;
                    break;
            }
            Console.ForegroundColor = consoleColor;
            Console.WriteLine($"[{level}]".PadRight(13,' ')+message);

            Console.ForegroundColor = consoleOldColor;
        }
    }
}

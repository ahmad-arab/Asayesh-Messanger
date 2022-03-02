
using System;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace AsayeshMessenger.Core
{

    public class TaskManager : ITaskManager
    {
        #region Methods
        public async Task Run(Func<Task> function, [CallerMemberName] string origin = "",
            [CallerFilePath] string filePath = "",
            [CallerLineNumber] int lineNumber = 0)
        {
            try
            {
                await Task.Run(function);
            }
            catch(Exception ex)
            {
                LogError(ex, origin, filePath, lineNumber);

                throw;
            }
        }

        public Task<TResult> Run<TResult>(Func<Task<TResult>> function, CancellationToken cancellationToken, [CallerMemberName] string origin = "",
            [CallerFilePath] string filePath = "",
            [CallerLineNumber] int lineNumber = 0)
        {
            try
            {
                return Task.Run(function, cancellationToken);
            }
            catch (Exception ex)
            {
                LogError(ex);

                throw;
            }
        }

        public Task<TResult> Run<TResult>(Func<Task<TResult>> function, [CallerMemberName] string origin = "",
            [CallerFilePath] string filePath = "",
            [CallerLineNumber] int lineNumber = 0)
        {
            try
            {
                return Task.Run(function);
            }
            catch (Exception ex)
            {
                LogError(ex);

                throw;
            }
        }

        public Task<TResult> Run<TResult>(Func<TResult> function, CancellationToken cancellationToken, [CallerMemberName] string origin = "",
            [CallerFilePath] string filePath = "",
            [CallerLineNumber] int lineNumber = 0)
        {
            try
            {
                return Task.Run(function, cancellationToken);
            }
            catch (Exception ex)
            {
                LogError(ex);

                throw;
            }
        }

        public Task<TResult> Run<TResult>(Func<TResult> function, [CallerMemberName] string origin = "",
            [CallerFilePath] string filePath = "",
            [CallerLineNumber] int lineNumber = 0)
        {
            try
            {
                return Task.Run(function);
            }
            catch (Exception ex)
            {
                LogError(ex);

                throw;
            }
        }

        public Task Run(Func<Task> function, CancellationToken cancellationToken, [CallerMemberName] string origin = "",
            [CallerFilePath] string filePath = "",
            [CallerLineNumber] int lineNumber = 0)
        {
            try
            {
                return Task.Run(function, cancellationToken);
            }
            catch (Exception ex)
            {
                LogError(ex);

                throw;
            }
        }

        public Task Run(Action action, CancellationToken cancellationToken, [CallerMemberName] string origin = "",
            [CallerFilePath] string filePath = "",
            [CallerLineNumber] int lineNumber = 0)
        {
            try
            {
                return Task.Run(action, cancellationToken);
            }
            catch (Exception ex)
            {
                LogError(ex);

                throw;
            }
        }

        public Task Run(Action action, [CallerMemberName] string origin = "",
            [CallerFilePath] string filePath = "",
            [CallerLineNumber] int lineNumber = 0)
        {
            try
            {
                return Task.Run(action);
            }
            catch (Exception ex)
            {
                LogError(ex);

                throw;
            }
        }
        #endregion

        #region Private Helper Methods

        private void LogError(Exception ex, [CallerMemberName] string origin = "",
            [CallerFilePath] string filePath = "",
            [CallerLineNumber] int lineNumber = 0)
        {
            IoC.Logger.Log($"An unexpected error occured running IoC.Task.Run. {ex.Message}", LogLevel.Debug,origin, filePath,lineNumber);
        }

        #endregion
    }
}

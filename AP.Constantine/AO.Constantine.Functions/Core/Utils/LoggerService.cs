using Amazon.Lambda.Core;
using System;

namespace AP.Constantine.Functions.Core.Utils
{
    /// <summary>
     /// Logger service, working with LambdaLogger.
     /// </summary>
    public interface ILoggerService
    {
        /// <summary>
        /// Log message.
        /// </summary>
        /// <param name="message">Message.</param>
        void Log(string message);

        /// <summary>
        /// Log message and exception.
        /// </summary>
        /// <param name="message">Message.</param>
        /// <param name="ex">Exception.</param>
        void Log(string message, Exception ex);
    }

    /// <inheritdoc />
    public class LoggerService : ILoggerService
    {
        /// <inheritdoc />
        public void Log(string message)
        {
            LambdaLogger.Log($"{message}");
        }

        /// <inheritdoc />
        public void Log(string message, Exception ex)
        {
            LambdaLogger.Log($"{message}{Environment.NewLine}{ex}");
        }
    }
}

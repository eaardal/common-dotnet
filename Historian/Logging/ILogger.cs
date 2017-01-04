using System;
using Historian.Logging.LogFactories;

namespace Historian.Logging
{
    /// <summary>
    /// A convenience wrapper for logging.
    /// </summary>
    public interface ILogger
    {
        /// <summary>
        /// Initializes the log factories to use when logging messages
        /// </summary>
        /// <param name="logFactories">The log factories to use when logging messages</param>
        void InitializeLogFactories(params ILogFactory[] logFactories);

        /// <summary>
        /// Logs using the provided action
        /// </summary>
        /// <param name="sourceOfLogMessage">The source object of where the log message originated</param>
        /// <param name="logAction">The log action to perform for each logger registered</param>
        /// <returns></returns>
        void Log(object sourceOfLogMessage, Action<ILog> logAction);

        /// <summary>
        /// Logs using the provided action
        /// </summary>
        /// <param name="sourceOfLogMsg">The source object of where the log message originated</param>
        /// <param name="logAction">The log action to perform for each logger registered</param>
        /// <returns></returns>
        void Log(Type sourceOfLogMsg, Action<ILog> logAction);

        /// <summary>
        /// Logs using the provided action
        /// </summary>
        /// <typeparam name="TSourceOfLogMsg">The source object of where the log message originated</typeparam>
        /// <param name="logAction">The log action to perform for each logger registered</param>
        /// <returns></returns>
        void Log<TSourceOfLogMsg>(Action<ILog> logAction);
    }
}
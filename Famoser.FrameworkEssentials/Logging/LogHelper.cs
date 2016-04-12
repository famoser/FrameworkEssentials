using System;
using System.Collections.Generic;
using Famoser.FrameworkEssentials.Logging.Interfaces;
using Famoser.FrameworkEssentials.Singleton;

namespace Famoser.FrameworkEssentials.Logging
{
    public class LogHelper : SingletonBase<LogHelper>, IExceptionLogger
    {
        private ILogger _logger;

        public LogHelper()
        {
            _logger = new Logger();
        }

        public void OverwriteLogger(ILogger logger)
        {
            _logger = logger;
        }

        public void Log(LogLevel level, string message, object from = null, Exception ex = null)
        {
            var lm = new LogModel
            {
                LogLevel = level,
                Message = message
            };

            if (from != null)
            {
                if (from is string)
                    lm.Location = (string)from;
                else
                    lm.Location = from.GetType().Namespace + "." + from.GetType().Name;
            }

            if (ex != null)
                lm.Message += ex.ToString();

            _logger.AddLog(lm);
        }

        public void LogException(Exception ex, object from = null)
        {
            Log(LogLevel.Error, "Exception occured", from, ex);
        }

        public void LogInfo(string message, object from = null, Exception ex = null)
        {
            Log(LogLevel.Info, message, from, ex);
        }

        public void LogWarning(string message, object from = null, Exception ex = null)
        {
            Log(LogLevel.Warning, message, from, ex);
        }

        public void LogError(string message, object from = null, Exception ex = null)
        {
            Log(LogLevel.Error, message, from, ex);
        }

        public void LogFatalError(string message, object from = null, Exception ex = null)
        {
            Log(LogLevel.FatalError, message, from, ex);
        }

        public ILogger GetImplementation()
        {
            return _logger;
        }

        public List<LogModel> GetLogs(bool clearAfterwards = true)
        {
            return _logger.GetLogs(clearAfterwards);
        } 
    }
}

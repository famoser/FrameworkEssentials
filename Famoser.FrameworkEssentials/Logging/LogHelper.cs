using System;
using System.Collections.Generic;
using Famoser.FrameworkEssentials.Singleton;

namespace Famoser.FrameworkEssentials.Logging
{
    public class LogHelper : SingletonBase<LogHelper>
    {
        private List<LogModel> _logs = new List<LogModel>();

        public void Log(LogLevel level, object from, string message, Exception ex = null)
        {
            var lm = new LogModel
            {
                LogLevel = level,
                Message = message
            };

            if (from != null)
                lm.Location = from.GetType().Namespace + "." + from.GetType().Name;

            if (ex != null)
                lm.Message += ex.ToString();

            _logs.Add(lm);
        }

        public void LogException(Exception ex, object from = null)
        {
            var lm = new LogModel
            {
                LogLevel = LogLevel.Error,
                Message = "Exception occured"
            };

            if (from != null)
                lm.Location = from.GetType().Namespace + "." + from.GetType().Name;

            if (ex != null)
                lm.Message += ex.ToString();

            _logs.Add(lm);
        }

        public void Log(LogLevel level, string from, string message, Exception ex = null)
        {
            var lm = new LogModel
            {
                LogLevel = level,
                Message = message
            };

            if (from != null)
                lm.Location = from;

            if (ex != null)
                lm.Message += ex.ToString();

            _logs.Add(lm);
        }

        public List<LogModel> GetAllLogs()
        {
            var templogs = new List<LogModel>(_logs);
            _logs = new List<LogModel>();
            return templogs;
        }
    }
}

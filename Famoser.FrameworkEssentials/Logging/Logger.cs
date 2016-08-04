using System.Collections.Generic;
using Famoser.FrameworkEssentials.Logging.Interfaces;

namespace Famoser.FrameworkEssentials.Logging
{
    /// <summary>
    /// This is a simple thread safe implementation of the ILogger interface. Feel free to provide your own and register it in the LogHelper
    /// </summary>
    public class Logger : ILogger
    {
        private readonly List<LogModel> _logs = new List<LogModel>();

        public void AddLog(LogModel model)
        {
            lock (this)
            {
                _logs.Add(model);
            }
        }

        public void ClearLogs()
        {
            lock (this)
            {
                _logs.Clear();
            }
        }

        public List<LogModel> GetLogs(bool clearAfterwards = true)
        {
            lock (this)
            {
                var templogs = new List<LogModel>(_logs);
                if (clearAfterwards)
                {
                    _logs.Clear();
                }
                return templogs;
            }
        }
    }
}

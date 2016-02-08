using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Famoser.FrameworkEssentials.Logging.Interfaces;

namespace Famoser.FrameworkEssentials.Logging
{
    public class Logger : ILogger
    {
        private readonly List<LogModel> _logs = new List<LogModel>();

        public void AddLog(LogModel model)
        {
            _logs.Add(model);
        }

        public void ClearLogs()
        {
            _logs.Clear();
        }

        public List<LogModel> GetLogs(bool clearAfterwards = true)
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Famoser.FrameworkEssentials.Logging.Interfaces
{
    public interface ILogger
    {
        void AddLog(LogModel model);
        void ClearLogs();
        List<LogModel> GetLogs(bool clearAfterwards = true);
    }
}

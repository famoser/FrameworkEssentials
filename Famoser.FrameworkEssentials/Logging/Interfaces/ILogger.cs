using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Famoser.FrameworkEssentials.Logging.Interfaces
{
    /// <summary>
    /// The ILogger interface is used by the LogHelper 
    /// An implementation of this interface is already provided
    /// </summary>
    public interface ILogger
    {
        /// <summary>
        /// Add a new Log
        /// </summary>
        /// <param name="model"></param>
        void AddLog(LogModel model);
        /// <summary>
        /// Remove all logs
        /// </summary>
        void ClearLogs();
        /// <summary>
        /// Retreive all logs
        /// </summary>
        /// <param name="clearAfterwards">if true ClearLogs() is called right after</param>
        /// <returns></returns>
        List<LogModel> GetLogs(bool clearAfterwards = true);
    }
}

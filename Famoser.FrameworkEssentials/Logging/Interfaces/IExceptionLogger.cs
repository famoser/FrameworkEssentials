using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Famoser.FrameworkEssentials.Logging.Interfaces
{
    public interface IExceptionLogger
    {
        void LogException(Exception ex, object from = null);
    }
}

using System;

namespace Famoser.FrameworkEssentials.Logging.Interfaces
{
    public interface IExceptionLogger
    {
        void LogException(Exception ex, object from = null);
    }
}

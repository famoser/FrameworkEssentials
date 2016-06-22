using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Famoser.FrameworkEssentials.Logging.Interfaces;

namespace Famoser.FrameworkEssentials.Services.Base
{
    public abstract class BaseService
    {
        private IExceptionLogger _logger;
        private bool _catchExceptions;

        protected BaseService(bool catchExceptions = true, IExceptionLogger logger = null)
        {
            _catchExceptions = catchExceptions;
            _logger = logger;
        }

        public void SetExceptionLogger(IExceptionLogger exceptionLogger)
        {
            _logger = exceptionLogger;
        }

        public void SetCatchExceptions(bool value)
        {
            _catchExceptions = value;
        }

        protected T Execute<T>(Func<T> func)
        {
            if (_catchExceptions)
            {
                try
                {
                    return func();
                }
                catch (Exception ex)
                {
                    _logger?.LogException(ex, this);
                }
                return default(T);
            }
            return func();
        }
    }
}

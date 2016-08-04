using System;
using System.Threading.Tasks;
using Famoser.FrameworkEssentials.Logging;
using Famoser.FrameworkEssentials.Logging.Interfaces;

namespace Famoser.FrameworkEssentials.Helpers
{
    public class BaseHelper
    {
        private static IExceptionLogger _exceptionLogger = LogHelper.Instance;


        protected static void SetExceptionLogger(IExceptionLogger exceptionLogger)
        {
            _exceptionLogger = exceptionLogger;
        }

        protected static T ExecuteSafe<T>(Func<T> func)
        {
            try
            {
                return func();
            }
            catch (Exception ex)
            {
                _exceptionLogger?.LogException(ex);
            }
            return default(T);
        }

        protected static async Task ExecuteSafe(Func<Task> func)
        {
            try
            {
                await func();
            }
            catch (Exception ex)
            {
                _exceptionLogger?.LogException(ex);
            }
            return;
        }

        protected static async Task<T> ExecuteSafe<T>(Func<Task<T>> func)
        {
            try
            {
                return await func();
            }
            catch (Exception ex)
            {
                _exceptionLogger?.LogException(ex);
            }
            return default(T);
        }
    }
}

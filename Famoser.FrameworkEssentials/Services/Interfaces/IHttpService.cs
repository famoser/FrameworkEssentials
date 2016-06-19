using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Famoser.FrameworkEssentials.Models.RestService;

namespace Famoser.FrameworkEssentials.Services.Interfaces
{
    /// <summary>
    /// A simple service to execute web requests
    /// </summary>
    public interface IHttpService
    {
        /// <summary>
        /// Fetch the response of the uri into the HttpResponseModel
        /// </summary>
        /// <param name="uri"></param>
        /// <returns></returns>
        Task<HttpResponseModel> DownloadAsync(Uri uri);
        /// <summary>
        /// perform a get request at this uri and return a value indicating if request was successfull
        /// </summary>
        /// <param name="uri"></param>
        /// <returns></returns>
        Task<bool> RequestAsync(Uri uri);
        /// <summary>
        /// perform a get request at this uri but do not wait for execution or result
        /// </summary>
        /// <param name="uri"></param>
        void FireAndForget(Uri uri);
    }
}

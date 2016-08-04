using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Famoser.FrameworkEssentials.Logging.Interfaces;
using Famoser.FrameworkEssentials.Models.RestService;
using Famoser.FrameworkEssentials.Services.Base;
using Famoser.FrameworkEssentials.Services.Interfaces;

namespace Famoser.FrameworkEssentials.Services
{
    /// <summary>
    /// This is an implementation of the IHttpService interface
    /// </summary>
    public class HttpService : HttpRequestService, IHttpService
    {
        public HttpService(IDictionary<string, string> additionalHeaders = null, bool catchExceptions = true, IExceptionLogger logger = null) : base(additionalHeaders, catchExceptions, logger) { }

        public Task<HttpResponseModel> DownloadAsync(Uri uri)
        {
            return ExecuteHttpRequest(async () =>
            {
                var client = GetClient();
               return await client.GetAsync(uri);
            });
        }

        public async Task<bool> RequestAsync(Uri uri)
        {
            var res = await ExecuteHttpRequest(async () =>
            {
                var client = GetClient();
                return await client.GetAsync(uri);
            });
            return res.IsRequestSuccessfull;
        }

        public void FireAndForget(Uri uri)
        {
            var client = GetClient();
            client.GetAsync(uri);
        }
    }
}

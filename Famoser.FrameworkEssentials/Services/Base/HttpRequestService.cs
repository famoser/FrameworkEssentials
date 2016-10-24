using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Famoser.FrameworkEssentials.Logging.Interfaces;
using Famoser.FrameworkEssentials.Models.RestService;

namespace Famoser.FrameworkEssentials.Services.Base
{
    /// <summary>
    /// A thread safe base class which constructs a single HttpClient objects with additional headers (if applicable)
    /// Call Dispose() to dispose the HttpClient
    /// </summary>
    public class HttpRequestService : BaseService, IDisposable
    {
        public HttpRequestService(IDictionary<string, string> additionalHeaders, bool catchExceptions = true, IExceptionLogger logger = null) : base(catchExceptions, logger)
        {
            _client = new HttpClient(
                new HttpClientHandler
                {
                    AutomaticDecompression = DecompressionMethods.GZip
                                             | DecompressionMethods.Deflate
                });

            _client.DefaultRequestHeaders.TryAddWithoutValidation("Accept-Encoding", "gzip, deflate");
            if (additionalHeaders != null)
                foreach (var additionalHeader in additionalHeaders)
                {
                    _client.DefaultRequestHeaders.TryAddWithoutValidation(additionalHeader.Key,
                        additionalHeader.Value);
                }
        }

        private readonly HttpClient _client;
        protected HttpClient GetClient()
        {
            return _client;
        }

        protected Task<HttpResponseModel> ExecuteHttpRequest(Func<Task<HttpResponseMessage>> func)
        {
            return Execute(async () =>
            {
                var res = await func();
                return new HttpResponseModel(res);
            });
        }

        private bool _isDisposed;
        protected virtual void Dispose(bool dispose)
        {
            if (!_isDisposed)
            {
                if (dispose)
                    _client.Dispose();
            }
            _isDisposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}

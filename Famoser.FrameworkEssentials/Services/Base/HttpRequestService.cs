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
        private readonly IDictionary<string, string> _additionalHeaders;
        public HttpRequestService(IDictionary<string, string> additionalHeaders, bool catchExceptions = true, IExceptionLogger logger = null) : base(catchExceptions, logger)
        {
            _additionalHeaders = additionalHeaders;
        }

        private HttpClient _client;
        protected HttpClient GetClient()
        {
            lock (this)
            {
                if (_client == null)
                {
                    _client = new HttpClient(
                        new HttpClientHandler
                        {
                            AutomaticDecompression = DecompressionMethods.GZip
                                                     | DecompressionMethods.Deflate
                        });

                    _client.DefaultRequestHeaders.TryAddWithoutValidation("Accept-Encoding", "gzip, deflate");
                    if (_additionalHeaders != null)
                        foreach (var additionalHeader in _additionalHeaders)
                        {
                            _client.DefaultRequestHeaders.TryAddWithoutValidation(additionalHeader.Key,
                                additionalHeader.Value);
                        }
                }
                return _client;
            }
        }
        
        protected Task<HttpResponseModel> ExecuteHttpRequest(Func<Task<HttpResponseMessage>> func)
        {
            return Execute(async () =>
            {
                var res = await func();
                return new HttpResponseModel(res);
            });
        }

        public void Dispose()
        {
            lock (this)
            {
                if (_client != null)
                {
                    _client.Dispose();
                    _client = null;
                }
            }
        }
    }
}

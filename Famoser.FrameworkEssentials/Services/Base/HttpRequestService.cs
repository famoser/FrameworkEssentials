using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Famoser.FrameworkEssentials.Services.Base
{
    /// <summary>
    /// A thread safe base class which constructs a single HttpClient objects with additional headers (if applicable)
    /// Call Dispose() to dispose the HttpClient
    /// </summary>
    public class HttpRequestService : IDisposable
    {
        private readonly IDictionary<string, string> _additionalHeaders;
        public HttpRequestService(IDictionary<string, string> additionalHeaders)
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

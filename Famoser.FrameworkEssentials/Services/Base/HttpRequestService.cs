using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Famoser.FrameworkEssentials.Services.Base
{
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

        public void Dispose()
        {
            _client.Dispose();
        }
    }
}

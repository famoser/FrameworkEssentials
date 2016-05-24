using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Famoser.FrameworkEssentials.Models.RestService;
using Famoser.FrameworkEssentials.Services.Base;
using Famoser.FrameworkEssentials.Services.Interfaces;

namespace Famoser.FrameworkEssentials.Services
{
    public class HttpService : HttpRequestService, IHttpService
    {
        public HttpService(IDictionary<string, string> additionalHeaders = null) : base(additionalHeaders) { }

        public async Task<HttpResponseModel> DownloadAsync(Uri uri)
        {
            try
            {
                var client = GetClient();
                var res = await client.GetAsync(uri);
                return new HttpResponseModel(res.Content, res.IsSuccessStatusCode);
            }
            catch (Exception ex)
            {
                return new HttpResponseModel(ex);
            }
        }

        public void FireAndForget(Uri uri)
        {
            var client = GetClient();
            client.GetAsync(uri);
        }
    }
}

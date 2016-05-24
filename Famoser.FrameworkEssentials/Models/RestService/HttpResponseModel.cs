using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace Famoser.FrameworkEssentials.Models.RestService
{
    /// <summary>
    /// This model is returned from http requests made with all HttpService, for example the RestService
    /// </summary>
    public class HttpResponseModel
    {
        public HttpResponseModel(HttpContent content, bool successfull)
        {
            HttpContent = content;
            IsRequestSuccessfull = successfull;
        }
        public HttpResponseModel(Exception ex)
        {
            Exception = ex;
            IsRequestSuccessfull = false;
        }

        public HttpContent HttpContent { get; }

        public bool IsRequestSuccessfull { get; }

        public Exception Exception { get; }

        public byte[] Response { get; set; }

        public Task<string> GetResponseAsStringAsync()
        {
            return HttpContent?.ReadAsStringAsync();
        }

        public Task<Stream> GetResponseAsStreamAsync()
        {
            return HttpContent?.ReadAsStreamAsync();
        }

        public Task<byte[]> GetResponseAsByteArrayAsync()
        {
            return HttpContent?.ReadAsByteArrayAsync();
        }
    }
}

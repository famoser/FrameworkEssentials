using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Famoser.FrameworkEssentials.Models
{
    public class RestResponseModel
    {
        public RestResponseModel(HttpContent content, bool successfull)
        {
            HttpContent = content;
            IsRequestSuccessfull = successfull;
        }
        public RestResponseModel(Exception ex)
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

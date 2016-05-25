using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace Famoser.FrameworkEssentials.Models.RestService
{
    /// <summary>
    /// This model is returned from http requests made with this packag (for example the RestService)
    /// </summary>
    public class HttpResponseModel : IDisposable
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

        /// <summary>
        /// Get the raw HttpContent
        /// </summary>
        public HttpContent HttpContent { get; }

        /// <summary>
        /// Check if the request was successfull
        /// </summary>
        public bool IsRequestSuccessfull { get; }

        /// <summary>
        /// Any Exception which might have occurred on execution of the request
        /// </summary>
        public Exception Exception { get; }

        /// <summary>
        /// Get response as a string. 
        /// This directly uses the HttpContent object, so do not dispose the service of the HttpContent prior
        /// </summary>
        /// <returns></returns>
        public Task<string> GetResponseAsStringAsync()
        {
            return HttpContent?.ReadAsStringAsync();
        }

        /// <summary>
        /// Get response as a stream. 
        /// This directly uses the HttpContent object, so do not dispose the service of the HttpContent prior
        /// </summary>
        /// <returns></returns>
        public Task<Stream> GetResponseAsStreamAsync()
        {
            return HttpContent?.ReadAsStreamAsync();
        }

        /// <summary>
        /// Get response as a byte array. 
        /// This directly uses the HttpContent object, so do not dispose the service of the HttpContent prior
        /// </summary>
        /// <returns></returns>
        public Task<byte[]> GetResponseAsByteArrayAsync()
        {
            return HttpContent?.ReadAsByteArrayAsync();
        }

        public void Dispose()
        {
            HttpContent?.Dispose();
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Famoser.FrameworkEssentials.Logging.Interfaces;
using Famoser.FrameworkEssentials.Models.RestService;
using Famoser.FrameworkEssentials.Services.Base;
using Famoser.FrameworkEssentials.Services.Interfaces;

namespace Famoser.FrameworkEssentials.Services
{
    /// <summary>
    /// This is an implementation of the IRestService interface
    /// </summary>
    public class RestService : HttpRequestService, IRestService
    {
        public RestService(IDictionary<string, string> additionalHeaders = null, bool catchExceptions = true, IExceptionLogger logger = null) : base(additionalHeaders, catchExceptions, logger) { }

        private HttpContent GetContent(IEnumerable<KeyValuePair<string, string>> postContent, IEnumerable<RestFile> files = null)
        {
            if (files == null)
                return new FormUrlEncodedContent(postContent);

            MultipartFormDataContent form = new MultipartFormDataContent();
            foreach (var keyValuePair in postContent)
            {
                var content = new StringContent(keyValuePair.Value);
                form.Add(content, keyValuePair.Key);
            }
            foreach (var restFile in files)
            {
                var content = new StreamContent(new MemoryStream(restFile.Content));
                form.Add(content, restFile.ContentName, restFile.FileName);
            }
            return form;
        }

        private HttpContent GetJsonContent(string json, IEnumerable<RestFile> files = null)
        {
            if (files == null)
                return new StringContent(json, Encoding.UTF8, "application/json");

            MultipartFormDataContent form = new MultipartFormDataContent
            {
                {new StringContent(json, Encoding.UTF8, "application/json"), "json"}
            };
            foreach (var restFile in files)
            {
                var content = new StreamContent(new MemoryStream(restFile.Content));
                form.Add(content, restFile.ContentName, restFile.FileName);
            }
            return form;
        }

        public Task<HttpResponseModel> GetAsync(Uri uri)
        {
            return ExecuteHttpRequest(async () =>
            {
                var client = GetClient();
                return await client.GetAsync(uri);
            });
        }

        public Task<HttpResponseModel> PutAsync(Uri uri, IEnumerable<KeyValuePair<string, string>> postContent, IEnumerable<RestFile> files = null)
        {
            return ExecuteHttpRequest(async () =>
            {
                var client = GetClient();
                var credentials = GetContent(postContent, files);

                return await client.PutAsync(uri, credentials);
            });
        }

        public Task<HttpResponseModel> PutJsonAsync(Uri uri, string json, IEnumerable<RestFile> files = null)
        {
            return ExecuteHttpRequest(async () =>
            {
                var client = GetClient();
                var credentials = GetJsonContent(json, files);

                return await client.PutAsync(uri, credentials);
            });
        }

        public Task<HttpResponseModel> PostAsync(Uri uri, IEnumerable<KeyValuePair<string, string>> postContent, IEnumerable<RestFile> files = null)
        {
            return ExecuteHttpRequest(async () =>
            {
                var client = GetClient();
                var credentials = GetContent(postContent, files);

                return await client.PostAsync(uri, credentials);
            });
        }

        public Task<HttpResponseModel> PostJsonAsync(Uri uri, string json, IEnumerable<RestFile> files = null)
        {
            return ExecuteHttpRequest(async () =>
            {
                var client = GetClient();
                var credentials = GetJsonContent(json, files);

                return await client.PostAsync(uri, credentials);
            });
        }

        public Task<HttpResponseModel> DeleteAsync(Uri uri)
        {
            return ExecuteHttpRequest(async () =>
            {
                var client = GetClient();
                return await client.DeleteAsync(uri);
            });
        }
    }
}

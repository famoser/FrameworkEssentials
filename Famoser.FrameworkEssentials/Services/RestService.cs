using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Famoser.FrameworkEssentials.Logging;
using Famoser.FrameworkEssentials.Models;
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
        public RestService(IDictionary<string, string> additionalHeaders = null) : base(additionalHeaders) { }

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

        public async Task<HttpResponseModel> GetAsync(Uri uri)
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

        public async Task<HttpResponseModel> PutAsync(Uri uri, IEnumerable<KeyValuePair<string, string>> postContent, IEnumerable<RestFile> files = null)
        {
            try
            {
                var client = GetClient();
                var credentials = GetContent(postContent, files);

                var res = await client.PutAsync(uri, credentials);
                return new HttpResponseModel(res.Content, res.IsSuccessStatusCode);
            }
            catch (Exception ex)
            {
                return new HttpResponseModel(ex);
            }
        }

        public async Task<HttpResponseModel> PutJsonAsync(Uri uri, string json, IEnumerable<RestFile> files = null)
        {
            try
            {
                var client = GetClient();
                var credentials = GetJsonContent(json, files);

                var res = await client.PutAsync(uri, credentials);
                return new HttpResponseModel(res.Content, res.IsSuccessStatusCode);
            }
            catch (Exception ex)
            {
                return new HttpResponseModel(ex);
            }
        }

        public async Task<HttpResponseModel> PostAsync(Uri uri, IEnumerable<KeyValuePair<string, string>> postContent, IEnumerable<RestFile> files = null)
        {
            try
            {
                var client = GetClient();
                var credentials = GetContent(postContent, files);

                var res = await client.PostAsync(uri, credentials);
                return new HttpResponseModel(res.Content, res.IsSuccessStatusCode);
            }
            catch (Exception ex)
            {
                return new HttpResponseModel(ex);
            }
        }

        public async Task<HttpResponseModel> PostJsonAsync(Uri uri, string json, IEnumerable<RestFile> files = null)
        {
            try
            {
                var client = GetClient();
                var credentials = GetJsonContent(json, files);

                var res = await client.PostAsync(uri, credentials);
                return new HttpResponseModel(res.Content, res.IsSuccessStatusCode);
            }
            catch (Exception ex)
            {
                return new HttpResponseModel(ex);
            }
        }

        public async Task<HttpResponseModel> DeleteAsync(Uri uri)
        {
            try
            {
                var client = GetClient();
                var res = await client.DeleteAsync(uri);
                return new HttpResponseModel(res.Content, res.IsSuccessStatusCode);
            }
            catch (Exception ex)
            {
                return new HttpResponseModel(ex);
            }
        }
    }
}

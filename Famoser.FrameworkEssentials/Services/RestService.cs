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
using Famoser.FrameworkEssentials.Services.Interfaces;

namespace Famoser.FrameworkEssentials.Services
{
    public class RestService : IRestService
    {
        private readonly IDictionary<string, string> _additionalHeaders;
        public RestService(IDictionary<string, string> additionalHeaders = null)
        {
            _additionalHeaders = additionalHeaders;
        }

        private HttpClient _client;
        private HttpClient GetClient()
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

        private HttpContent GetContent(IEnumerable<KeyValuePair<string, string>> postContent,
            IEnumerable<RestFile> files = null)
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

        public async Task<RestResponseModel> GetAsync(Uri uri)
        {
            try
            {
                var client = GetClient();
                var res = await client.GetAsync(uri);
                return new RestResponseModel(res.Content, res.IsSuccessStatusCode);
            }
            catch (Exception ex)
            {
                return new RestResponseModel(ex);
            }
        }

        public async Task<RestResponseModel> PutAsync(Uri uri, IEnumerable<KeyValuePair<string, string>> postContent, IEnumerable<RestFile> files = null)
        {
            try
            {
                var client = GetClient();
                var credentials = GetContent(postContent, files);

                var res = await client.PutAsync(uri, credentials);
                return new RestResponseModel(res.Content, res.IsSuccessStatusCode);

            }
            catch (Exception ex)
            {
                return new RestResponseModel(ex);
            }
        }

        public async Task<RestResponseModel> PostAsync(Uri uri, IEnumerable<KeyValuePair<string, string>> postContent, IEnumerable<RestFile> files = null)
        {
            try
            {
                var client = GetClient();
                var credentials = GetContent(postContent, files);

                var res = await client.PostAsync(uri, credentials);
                return new RestResponseModel(res.Content, res.IsSuccessStatusCode);

            }
            catch (Exception ex)
            {
                return new RestResponseModel(ex);
            }
        }

        public async Task<RestResponseModel> DeleteAsync(Uri uri)
        {
            try
            {
                var client = GetClient();
                var res = await client.DeleteAsync(uri);
                return new RestResponseModel(res.Content, res.IsSuccessStatusCode);
            }
            catch (Exception ex)
            {
                return new RestResponseModel(ex);
            }
        }
    }
}

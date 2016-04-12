﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Famoser.FrameworkEssentials.Logging;
using Famoser.FrameworkEssentials.Models;
using Famoser.FrameworkEssentials.Services.Interfaces;

namespace Famoser.FrameworkEssentials.Services
{
    public class RestService : IRestService
    {
        private HttpClient GetClient(IDictionary<string, string> additionalHeaders = null)
        {
            var client = new HttpClient(
                new HttpClientHandler
                {
                    AutomaticDecompression = DecompressionMethods.GZip
                                             | DecompressionMethods.Deflate
                });

            client.DefaultRequestHeaders.TryAddWithoutValidation("Accept-Encoding", "gzip, deflate");
            if (additionalHeaders != null)
                foreach (var additionalHeader in additionalHeaders)
                {
                    client.DefaultRequestHeaders.TryAddWithoutValidation(additionalHeader.Key, additionalHeader.Value);
                }

            return client;
        }

        public async Task<RestResponseModel> GetAsync(Uri uri, IDictionary<string, string> additionalHeaders = null)
        {
            try
            {
                using (var client = GetClient(additionalHeaders))
                {
                    var res = await client.GetAsync(uri);
                    return new RestResponseModel(res.Content, res.IsSuccessStatusCode);
                }
            }
            catch (Exception ex)
            {
                return new RestResponseModel(ex);
            }
        }

        public async Task<RestResponseModel> PutAsync(Uri uri, IEnumerable<KeyValuePair<string, string>> postContent, IDictionary<string, string> additionalHeaders = null)
        {
            try
            {
                using (var client = GetClient(additionalHeaders))
                {
                    var credentials = new FormUrlEncodedContent(
                        postContent
                    );

                    var res = await client.PutAsync(uri, credentials);
                    return new RestResponseModel(res.Content, res.IsSuccessStatusCode);
                }
            }
            catch (Exception ex)
            {
                return new RestResponseModel(ex);
            }
        }

        public async Task<RestResponseModel> PostAsync(Uri uri, IEnumerable<KeyValuePair<string, string>> postContent, IDictionary<string, string> additionalHeaders = null)
        {
            try
            {
                using (var client = GetClient())
                {
                    var credentials = new FormUrlEncodedContent(
                        postContent
                    );

                    var res = await client.PostAsync(uri, credentials);
                    return new RestResponseModel(res.Content, res.IsSuccessStatusCode);
                }
            }
            catch (Exception ex)
            {
                return new RestResponseModel(ex);
            }
        }

        public async Task<RestResponseModel> DeleteAsync(Uri uri, IDictionary<string, string> additionalHeaders = null)
        {
            try
            {
                using (var client = GetClient(additionalHeaders))
                {
                    var res = await client.DeleteAsync(uri);
                    return new RestResponseModel(res.Content, res.IsSuccessStatusCode);
                }
            }
            catch (Exception ex)
            {
                return new RestResponseModel(ex);
            }
        }
    }
}

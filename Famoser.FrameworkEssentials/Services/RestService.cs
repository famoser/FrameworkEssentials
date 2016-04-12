using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Famoser.FrameworkEssentials.Interfaces;
using Famoser.FrameworkEssentials.Logging;
using Famoser.FrameworkEssentials.Models;

namespace Famoser.FrameworkEssentials.Services
{
    public class RestService : IRestService
    {
        public async Task<RestResponseModel> GetAsync(Uri uri, IEnumerable<KeyValuePair<string, string>> postContent)
        {
            RestResponseModel resp = null;
            try
            {
                using (var client = new HttpClient(
                    new HttpClientHandler
                    {
                        AutomaticDecompression = DecompressionMethods.GZip
                                                 | DecompressionMethods.Deflate
                    }))
                {
                    client.DefaultRequestHeaders.TryAddWithoutValidation("Accept-Encoding", "gzip, deflate");

                    var credentials = new FormUrlEncodedContent(
                        postContent
                    );

                    var res = await client.PostAsync(uri, credentials);
                    if (res.IsSuccessStatusCode)
                    {
                        
                    }
                        var respo = await res.Content.ReadAsStringAsync();
                    if (respo == "true")
                        resp = new BooleanResponse() { Response = true };
                    else
                    {
                        if (respo == "false")
                            resp = new BooleanResponse() { Response = false };
                        else
                        {
                            resp = new BooleanResponse() { ErrorMessage = respo };
                            LogHelper.Instance.Log(LogLevel.ApiError, this,
                                "Post failed for url " + url + " with json " + content + " Reponse recieved: " + respo);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LogHelper.Instance.Log(LogLevel.Error, this, "Post failed for url " + url, ex);
                resp = new BooleanResponse() { ErrorMessage = "Post failed for url " + url };
            }
            return resp;
        }

        public Task<RestResponseModel> PutAsync(Uri uri, IEnumerable<KeyValuePair<string, string>> postContent)
        {
            throw new NotImplementedException();
        }

        public Task<RestResponseModel> PostAsync(Uri uri, IEnumerable<KeyValuePair<string, string>> postContent)
        {
            throw new NotImplementedException();
        }

        public Task<RestResponseModel> DeleteAsync(Uri uri, IEnumerable<KeyValuePair<string, string>> postContent)
        {
            throw new NotImplementedException();
        }
    }
}

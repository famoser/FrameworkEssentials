using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Famoser.FrameworkEssentials.Models;
using Famoser.FrameworkEssentials.Models.RestService;

namespace Famoser.FrameworkEssentials.Services.Interfaces
{
    public interface IRestService
    {
        Task<HttpResponseModel> GetAsync(Uri uri);
        Task<HttpResponseModel> PutAsync(Uri uri, IEnumerable<KeyValuePair<string, string>> postContent, IEnumerable<RestFile> files = null);
        Task<HttpResponseModel> PutJsonAsync(Uri uri, string json);
        Task<HttpResponseModel> PostAsync(Uri uri, IEnumerable<KeyValuePair<string, string>> postContent, IEnumerable<RestFile> files = null);
        Task<HttpResponseModel> PostJsonAsync(Uri uri, string json);
        Task<HttpResponseModel> DeleteAsync(Uri uri);
    }
}

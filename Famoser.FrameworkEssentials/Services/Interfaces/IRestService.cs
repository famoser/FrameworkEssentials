using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Famoser.FrameworkEssentials.Models;
using Famoser.FrameworkEssentials.Models.RestService;

namespace Famoser.FrameworkEssentials.Services.Interfaces
{
    public interface IRestService
    {
        Task<RestResponseModel> GetAsync(Uri uri);
        Task<RestResponseModel> PutAsync(Uri uri, IEnumerable<KeyValuePair<string, string>> postContent, IEnumerable<RestFile> files = null);
        Task<RestResponseModel> PostAsync(Uri uri, IEnumerable<KeyValuePair<string, string>> postContent, IEnumerable<RestFile> files = null);
        Task<RestResponseModel> DeleteAsync(Uri uri);

        //todo: request with file
    }
}

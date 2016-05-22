using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Famoser.FrameworkEssentials.Models;

namespace Famoser.FrameworkEssentials.Services.Interfaces
{
    public interface IRestService
    {
        Task<RestResponseModel> GetAsync(Uri uri);
        Task<RestResponseModel> PutAsync(Uri uri, IEnumerable<KeyValuePair<string, string>> postContent);
        Task<RestResponseModel> PostAsync(Uri uri, IEnumerable<KeyValuePair<string, string>> postContent);
        Task<RestResponseModel> DeleteAsync(Uri uri);

        //todo: request with file
    }
}

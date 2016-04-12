using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Famoser.FrameworkEssentials.Models;

namespace Famoser.FrameworkEssentials.Services.Interfaces
{
    interface IRestService
    {
        Task<RestResponseModel> GetAsync(Uri uri, IDictionary<string, string> additionalHeaders = null);
        Task<RestResponseModel> PutAsync(Uri uri, IEnumerable<KeyValuePair<string, string>> postContent, IDictionary<string, string> additionalHeaders = null);
        Task<RestResponseModel> PostAsync(Uri uri, IEnumerable<KeyValuePair<string, string>> postContent, IDictionary<string, string> additionalHeaders = null);
        Task<RestResponseModel> DeleteAsync(Uri uri, IDictionary<string, string> additionalHeaders = null);
    }
}

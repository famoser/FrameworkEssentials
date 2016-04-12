using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Famoser.FrameworkEssentials.Models;

namespace Famoser.FrameworkEssentials.Interfaces
{
    interface IRestService
    {
        Task<RestResponseModel> GetAsync(Uri uri, IEnumerable<KeyValuePair<string, string>> postContent);
        Task<RestResponseModel> PutAsync(Uri uri, IEnumerable<KeyValuePair<string, string>> postContent);
        Task<RestResponseModel> PostAsync(Uri uri, IEnumerable<KeyValuePair<string, string>> postContent);
        Task<RestResponseModel> DeleteAsync(Uri uri, IEnumerable<KeyValuePair<string, string>> postContent);
    }
}

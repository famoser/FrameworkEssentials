using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Famoser.FrameworkEssentials.Models.RestService;

namespace Famoser.FrameworkEssentials.Services.Interfaces
{
    public interface IHttpService
    {
        Task<HttpResponseModel> DownloadAsync(Uri uri);
        void FireAndForget(Uri uri);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Famoser.FrameworkEssentials.Interfaces
{
    public interface IStorageService
    {
        /// <summary>
        /// Get cached Data (saved on every Device)
        /// </summary>
        /// <returns></returns>
        Task<string> GetCachedData(string fileKey);

        /// <summary>
        /// Set cached Data (saved on every Device)
        /// </summary>
        /// <returns></returns>
        Task<bool> SetCachedData(string fileKey, string content);

        /// <summary>
        /// Get User informations, the same for all devices of a single User. On UWP will be synched by windows.
        /// </summary>
        /// <returns></returns>
        Task<string> GetUserData(string fileKey);

        /// <summary>
        /// Set User informations, the same for all devices of a single User. On UWP will be synched by windows.
        /// </summary>
        /// <returns></returns>
        Task<bool> SetUserData(string fileKey, string content);
    }
}

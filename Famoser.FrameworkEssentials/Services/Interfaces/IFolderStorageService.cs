using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Famoser.FrameworkEssentials.Services.Interfaces
{
    public interface IFolderStorageService : IStorageService
    {
        Task<List<string>> GetCachedFiles(string subFolderPath);
        Task<List<string>> GetCachedDirectories(string subFolderPath);
        Task<List<string>> DeleteCachedDirectory(string subFolderPath);
        Task<List<string>> ClearCache();
        Task<List<string>> GetRoamingFiles(string subFolderPath);
        Task<List<string>> GetRoamingDirectories(string subFolderPath);
        Task<List<string>> DeleteRoamingDirectory(string subFolderPath);
        Task<List<string>> ClearRoaming();
    }
}

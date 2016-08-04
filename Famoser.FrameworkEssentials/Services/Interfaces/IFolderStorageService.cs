using System.Collections.Generic;
using System.Threading.Tasks;

namespace Famoser.FrameworkEssentials.Services.Interfaces
{
    public interface IFolderStorageService : IStorageService
    {
        Task<List<string>> GetCachedFiles(string subFolderPath);
        Task<List<string>> GetCachedDirectories(string subFolderPath);
        Task<bool> DeleteCachedDirectory(string subFolderPath);
        Task<bool> ClearCache();
        Task<List<string>> GetRoamingFiles(string subFolderPath);
        Task<List<string>> GetRoamingDirectories(string subFolderPath);
        Task<bool> DeleteRoamingDirectory(string subFolderPath);
        Task<bool> ClearRoaming();
    }
}

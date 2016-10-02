using System.Threading.Tasks;

namespace Famoser.FrameworkEssentials.Services.Interfaces.Storage
{
    public interface IRoamingStorageService
    {
        /// <summary>
        /// Get Roaming informations, the same for all devices of a single User. On UWP will be synched by windows.
        /// </summary>
        /// <returns></returns>
        Task<string> GetRoamingTextFileAsync(string filePath);

        /// <summary>
        /// Set Roaming informations, the same for all devices of a single User. On UWP will be synched by windows.
        /// </summary>
        /// <returns></returns>
        Task<bool> SetRoamingTextFileAsync(string filePath, string content);

        /// <summary>
        /// Get Roaming informations, the same for all devices of a single User. On UWP will be synched by windows.
        /// </summary>
        /// <returns></returns>
        Task<byte[]> GetRoamingFileAsync(string filePath);

        /// <summary>
        /// Set Roaming informations, the same for all devices of a single User. On UWP will be synched by windows.
        /// </summary>
        /// <returns></returns>
        Task<bool> SetRoamingFileAsync(string filePath, byte[] content);

        /// <summary>
        /// Set Roaming informations, the same for all devices of a single User. On UWP will be synched by windows.
        /// </summary>
        /// <returns></returns>
        Task<bool> DeleteRoamingFileAsync(string filePath);
    }
}

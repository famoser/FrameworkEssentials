using System.Threading.Tasks;

namespace Famoser.FrameworkEssentials.Services.Interfaces
{
    public interface IStorageService
    {
        /// <summary>
        /// Get cached Data (saved on every Device)
        /// </summary>
        /// <returns></returns>
        Task<string> GetCachedTextFileAsync(string fileKey);

        /// <summary>
        /// Set cached Data (saved on every Device)
        /// </summary>
        /// <returns></returns>
        Task<bool> SetCachedTextFileAsync(string fileKey, string content);

        /// <summary>
        /// Get cached Data (saved on every Device)
        /// </summary>
        /// <returns></returns>
        Task<byte[]> GetCachedFileAsync(string fileKey);

        /// <summary>
        /// Set cached Data (saved on every Device)
        /// </summary>
        /// <returns></returns>
        Task<bool> SetCachedFileAsync(string fileKey, byte[] content);

        /// <summary>
        /// Get User informations, the same for all devices of a single User. On UWP will be synched by windows.
        /// </summary>
        /// <returns></returns>
        Task<string> GetUserTextFileAsync(string fileKey);

        /// <summary>
        /// Set User informations, the same for all devices of a single User. On UWP will be synched by windows.
        /// </summary>
        /// <returns></returns>
        Task<bool> SetUserTextFileAsync(string fileKey, string content);

        /// <summary>
        /// Get User informations, the same for all devices of a single User. On UWP will be synched by windows.
        /// </summary>
        /// <returns></returns>
        Task<byte[]> GetUserFileAsync(string fileKey);

        /// <summary>
        /// Set User informations, the same for all devices of a single User. On UWP will be synched by windows.
        /// </summary>
        /// <returns></returns>
        Task<bool> SetUserFileAsync(string fileKey, byte[] content);

        /// <summary>
        /// Get asset file (file from solution, mark it as build:content & copy always)
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        Task<string> GetAssetTextFileAsync(string path);

        /// <summary>
        /// Get asset file (file from solution, mark it as build:content & copy always)
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        Task<byte[]> GetAssetFileAsync(string path);
    }
}
using System.Threading.Tasks;

namespace Famoser.FrameworkEssentials.Services.Interfaces.Storage
{
    public interface ICacheStorageService
    {
        /// <summary>
        /// Get cached Data (saved on every Device)
        /// </summary>
        /// <returns></returns>
        Task<string> GetCachedTextFileAsync(string filePath);

        /// <summary>
        /// Set cached Data (saved on every Device)
        /// </summary>
        /// <returns></returns>
        Task<bool> SetCachedTextFileAsync(string filePath, string content);

        /// <summary>
        /// Get cached Data (saved on every Device)
        /// </summary>
        /// <returns></returns>
        Task<byte[]> GetCachedFileAsync(string filePath);

        /// <summary>
        /// Set cached Data (saved on every Device)
        /// </summary>
        /// <returns></returns>
        Task<bool> SetCachedFileAsync(string filePath, byte[] content);

        /// <summary>
        /// Set cached Data (saved on every Device)
        /// </summary>
        /// <returns></returns>
        Task<bool> DeleteCachedFileAsync(string filePath);
    }
}

using System.Threading.Tasks;

namespace Famoser.FrameworkEssentials.Services.Interfaces.Storage
{
    public interface IAssetStorageService
    {
        /// <summary>
        /// Get asset file (file from solution, mark it as build:content & copy always)
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        Task<string> GetAssetTextFileAsync(string filePath);

        /// <summary>
        /// Get asset file (file from solution, mark it as build:content & copy always)
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        Task<byte[]> GetAssetFileAsync(string filePath);
    }
}

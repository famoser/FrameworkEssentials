using System;
using System.Threading.Tasks;

namespace Famoser.FrameworkEssentials.Services.Interfaces
{
    /// <summary>
    /// An interface of a storage service which is implemented for UWP in the package Famoser.FrameworkEssentials.UniversalEssentials
    /// </summary>
    public interface IStorageService
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
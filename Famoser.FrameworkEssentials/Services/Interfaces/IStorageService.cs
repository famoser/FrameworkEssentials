using Famoser.FrameworkEssentials.Services.Interfaces.Storage;

namespace Famoser.FrameworkEssentials.Services.Interfaces
{
    /// <summary>
    /// An interface of a storage service which is implemented for UWP in the package Famoser.FrameworkEssentials.UniversalEssentials
    /// </summary>
    public interface IStorageService : ICacheStorageService, IRoamingStorageService, IAssetStorageService
    {
    }
}
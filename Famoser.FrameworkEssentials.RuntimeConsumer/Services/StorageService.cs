using System;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Storage;
using Famoser.FrameworkEssentials.Logging.Interfaces;
using Famoser.FrameworkEssentials.Models;
using Famoser.FrameworkEssentials.Services.Interfaces;

namespace Famoser.FrameworkEssentials.RuntimeConsumer.Services
{
    internal class StorageService : IStorageService
    {
        private readonly IExceptionLogger _logger;
        public StorageService(IExceptionLogger logger = null)
        {
            _logger = logger;
        }

        protected async Task<string> ReadAssetTextFileAsync(string path)
        {
            try
            {
                StorageFile file = await StorageFile.GetFileFromApplicationUriAsync(new Uri("ms-appx:///" + path));
                return await FileIO.ReadTextAsync(file);
            }
            catch (Exception ex)
            {
                _logger?.LogException(ex, this);
            }
            return null;
        }

        protected async Task<string> ReadLocalTextFileAsync(string filename)
        {
            try
            {
                StorageFile localFile = await ApplicationData.Current.LocalFolder.GetFileAsync(filename);
                if (localFile != null)
                {
                    return await FileIO.ReadTextAsync(localFile);
                }
            }
            catch (Exception ex)
            {
                _logger?.LogException(ex, this);
            }
            return null;
        }

        protected async Task<string> ReadRoamingTextFileAsync(string filename)
        {
            try
            {
                StorageFile localFile = await ApplicationData.Current.RoamingFolder.GetFileAsync(filename);
                if (localFile != null)
                {
                    return await FileIO.ReadTextAsync(localFile);
                }
            }
            catch (Exception ex)
            {
                _logger?.LogException(ex, this);
            }
            return null;
        }

        protected async Task<bool> SaveLocalTextFileAsync(string filename, string content)
        {
            try
            {
                StorageFile localFile = await ApplicationData.Current.LocalFolder.CreateFileAsync(filename, CreationCollisionOption.ReplaceExisting);
                if (localFile != null)
                {
                    await FileIO.WriteTextAsync(localFile, content);
                    return true;
                }
            }
            catch (Exception ex)
            {
                _logger.LogException(ex, this);
            }
            return false;
        }

        protected async Task<bool> SaveRoamingTextFileAsync(string filename, string content)
        {
            try
            {
                StorageFile localFile = await ApplicationData.Current.RoamingFolder.CreateFileAsync(filename, CreationCollisionOption.ReplaceExisting);
                if (localFile != null)
                {
                    await FileIO.WriteTextAsync(localFile, content);
                    return true;
                }
            }
            catch (Exception ex)
            {
                _logger.LogException(ex, this);
            }
            return false;
        }

        protected async Task<byte[]> ReadAssetFileAsync(string path)
        {
            try
            {
                StorageFile file = await StorageFile.GetFileFromApplicationUriAsync(new Uri("ms-appx:///" + path));
                var str = await FileIO.ReadBufferAsync(file);
                return str.ToArray();
            }
            catch (Exception ex)
            {
                _logger?.LogException(ex, this);
            }
            return null;
        }

        protected async Task<byte[]> ReadLocalFileAsync(string filename)
        {
            try
            {
                StorageFile localFile = await ApplicationData.Current.LocalFolder.GetFileAsync(filename);
                if (localFile != null)
                {
                    var str = await FileIO.ReadBufferAsync(localFile);
                    return str.ToArray();
                }
            }
            catch (Exception ex)
            {
                _logger?.LogException(ex, this);
            }
            return null;
        }

        protected async Task<byte[]> ReadRoamingFileAsync(string filename)
        {
            try
            {
                StorageFile localFile = await ApplicationData.Current.RoamingFolder.GetFileAsync(filename);
                if (localFile != null)
                {
                    var res =  await FileIO.ReadBufferAsync(localFile);
                    return res.ToArray();
                }
            }
            catch (Exception ex)
            {
                _logger?.LogException(ex, this);
            }
            return null;
        }

        protected async Task<bool> SaveLocalFileAsync(string filename, byte[] content)
        {
            try
            {
                StorageFile localFile = await ApplicationData.Current.LocalFolder.CreateFileAsync(filename, CreationCollisionOption.ReplaceExisting);
                if (localFile != null)
                {
                    await FileIO.WriteBytesAsync(localFile, content);
                    return true;
                }
            }
            catch (Exception ex)
            {
                _logger.LogException(ex, this);
            }
            return false;
        }

        protected async Task<bool> SaveRoamingFileAsync(string filename, byte[] content)
        {
            try
            {
                StorageFile localFile = await ApplicationData.Current.RoamingFolder.CreateFileAsync(filename, CreationCollisionOption.ReplaceExisting);
                if (localFile != null)
                {
                    await FileIO.WriteBytesAsync(localFile, content);
                    return true;
                }
            }
            catch (Exception ex)
            {
                _logger.LogException(ex, this);
            }
            return false;
        }

        public Task<string> GetCachedTextFileAsync(string fileKey)
        {
            return ReadRoamingTextFileAsync(fileKey);
        }

        public Task<bool> SetCachedTextFileAsync(string fileKey, string content)
        {
            return SaveRoamingTextFileAsync(fileKey, content);
        }

        public Task<byte[]> GetCachedFileAsync(string fileKey)
        {
            return ReadRoamingFileAsync(fileKey);
        }

        public Task<bool> SetCachedFileAsync(string fileKey, byte[] content)
        {
            return SaveRoamingFileAsync(fileKey, content);
        }

        public Task<string> GetUserTextFileAsync(string fileKey)
        {
            return ReadLocalTextFileAsync(fileKey);
        }

        public Task<bool> SetUserTextFileAsync(string fileKey, string content)
        {
            return SaveLocalTextFileAsync(fileKey, content);
        }

        public Task<byte[]> GetUserFileAsync(string fileKey)
        {
            return ReadRoamingFileAsync(fileKey);
        }

        public Task<bool> SetUserFileAsync(string fileKey, byte[] content)
        {
            return SaveRoamingFileAsync(fileKey, content);
        }

        public Task<string> GetAssetTextFileAsync(string path)
        {
            return ReadAssetTextFileAsync(path);
        }

        public Task<byte[]> GetAssetFileAsync(string path)
        {
            return ReadAssetFileAsync(path);
        }
    }
}

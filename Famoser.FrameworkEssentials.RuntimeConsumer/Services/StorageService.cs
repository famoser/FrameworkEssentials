using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Famoser.FrameworkEssentials.Services.Interfaces;

namespace Famoser.FrameworkEssentials.RuntimeConsumer.Services
{
    class StorageService : IStorageService
    {
        public Task GetCachedData(string fileKey)
        {
            throw new NotImplementedException();
        }

        public Task SetCachedData(string fileKey, string content)
        {
            throw new NotImplementedException();
        }

        public Task GetUserData(string fileKey)
        {
            throw new NotImplementedException();
        }

        public Task SetUserData(string fileKey, string content)
        {
            throw new NotImplementedException();
        }
    }
}

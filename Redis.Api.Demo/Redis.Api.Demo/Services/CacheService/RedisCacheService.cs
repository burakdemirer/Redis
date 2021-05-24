using StackExchange.Redis.Extensions.Core.Abstractions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Redis.Api.Demo.Services.CacheService
{
    public class RedisCacheService : ICacheService
    {
        private readonly IRedisCacheClient _redisCacheClient;

        public RedisCacheService(IRedisCacheClient redisCacheClient)
        {
            _redisCacheClient = redisCacheClient;
        }

        public async Task<T> Get<T>(string key)
        {
            return await _redisCacheClient.GetDbFromConfiguration().GetAsync<T>(key);
        }

        public async Task<IDictionary<string, T>> GetAll<T>(IEnumerable<string> keys)
        {
            return await _redisCacheClient.GetDbFromConfiguration().GetAllAsync<T>(keys);
        }

        public async Task<bool> Add<T>(string key, T value, DateTimeOffset expiresAt)
        {
            return await _redisCacheClient.GetDbFromConfiguration().AddAsync(key, value, expiresAt);
        }

        public async Task<bool> AddAll<T>(IList<Tuple<string, T>> items, DateTimeOffset expiresAt)
        {
            return await _redisCacheClient.GetDbFromConfiguration().AddAllAsync(items, expiresAt);
        }

        public async Task<bool> Remove(string key)
        {
            return await _redisCacheClient.GetDbFromConfiguration().RemoveAsync(key);
        }

        public async Task<long> RemoveAll(IEnumerable<string> keys)
        {
            return await _redisCacheClient.GetDbFromConfiguration().RemoveAllAsync(keys);
        }

        public async Task<IEnumerable<string>> Search(string pattern)
        {
            return await _redisCacheClient.GetDbFromConfiguration().SearchKeysAsync(pattern);
        }

        public async Task Clear()
        {
            await _redisCacheClient.GetDbFromConfiguration().FlushDbAsync();
        }

    }
}

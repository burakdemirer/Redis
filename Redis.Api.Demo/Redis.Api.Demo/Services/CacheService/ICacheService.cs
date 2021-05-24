using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Redis.Api.Demo.Services.CacheService
{
    public interface ICacheService
    {
        Task<T> Get<T>(string key);
        Task<IDictionary<string, T>> GetAll<T>(IEnumerable<string> keys);
        Task<bool> Add<T>(string key, T value, DateTimeOffset expiresAt);
        Task<bool> AddAll<T>(IList<Tuple<string, T>> items, DateTimeOffset expiresAt);
        Task<bool> Remove(string key);
        Task<long> RemoveAll(IEnumerable<string> keys);
        Task<IEnumerable<string>> Search(string pattern);
        Task Clear();
    }
}

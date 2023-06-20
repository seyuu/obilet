using Newtonsoft.Json;
using StackExchange.Redis;
using System.Threading.Tasks;

namespace obilet_core.Helpers.Caching
{
    public class RedisCacheProvider : ICacheProvider
    {
        private readonly IDatabase _cache;

        public RedisCacheProvider(string connectionString)
        {
            var connection = ConnectionMultiplexer.Connect(connectionString);
            _cache = connection.GetDatabase();
        }

        public async Task<T> GetAsync<T>(string key)
        {
            var value = await _cache.StringGetAsync(key);
            if (value.IsNullOrEmpty)
            {
                return default(T);
            }
            return JsonConvert.DeserializeObject<T>(value);
        }

        public async Task SetAsync<T>(string key, T value)
        {
            var serializedValue = JsonConvert.SerializeObject(value);
            await _cache.StringSetAsync(key, serializedValue);
        }
    }
}

using System.Threading.Tasks;

namespace obilet_core.Helpers.Caching
{
    public interface ICacheProvider
    {
        Task<T> GetAsync<T>(string key);
        Task SetAsync<T>(string key, T value);
    }
}

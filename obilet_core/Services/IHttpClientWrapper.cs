using System.Net.Http;
using System.Threading.Tasks;

namespace obilet_core.Services
{
    public interface IHttpClientWrapper
    {
        Task<HttpResponseMessage> PostAsync(string requestUri, HttpContent content);
    }
}

using Microsoft.AspNetCore.Mvc.Rendering;
using obilet_core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace obilet_core.Services
{
    public interface IApiService
    {
        Task<GetSessionResponseModel> GetSession();
        Task<GetBusLocationResponseModel> GetBusLocation(string data = "");
        Task<GetJourneysResponseModel> GetJourneys(QueryModel model);
        Task<List<SelectListItem>> GetBusLocationData();

	}
}

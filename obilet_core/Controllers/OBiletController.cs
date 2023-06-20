using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using obilet_core.Helpers.Validation;
using obilet_core.Models;
using obilet_core.Services;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace obilet_core.Controllers
{
    public class OBiletController : Controller
	{
		private readonly IApiService _apiService;
		private readonly IMemoryCache _cache;
        private readonly ILogger<OBiletController> _logger;

        public OBiletController(IApiService apiService, IMemoryCache cache, ILogger<OBiletController> logger)
		{
			_apiService = apiService;
			_cache = cache;
            _logger = logger;
        }

		public async Task<IActionResult> Index(string buttonClicked)
		{
			if (_cache.TryGetValue("LastQueryModel", out QueryModel cachedModel))
			{
				return RedirectToAction("Detail", cachedModel);
			}

			var busLocations = await _apiService.GetBusLocationData();

			var model = new QueryModel
			{
				OriginId = int.Parse(busLocations[0].Value),
				DestinationId = int.Parse(busLocations[1].Value),
				Date = DateTime.Now.AddDays(1)
			};

			ViewBag.BusLocations = busLocations;

			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> Index(QueryModel model, string buttonClicked)
		{
            if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			if (model.DestinationId == model.OriginId)
			{
                var errorMessage = EnumHelper.GetEnumDescription(Errors.SameOptions);

                ModelState.AddModelError("DestinationId", errorMessage);
                _logger.LogError(errorMessage);

                ViewBag.BusLocations = await _apiService.GetBusLocationData(); 

				return View(model);
			}

			if (model.Date < DateTime.Now)
			{
                var errorMessage = EnumHelper.GetEnumDescription(Errors.DateBeforeToday);

                ModelState.AddModelError("Date", errorMessage);
                _logger.LogError(errorMessage);

                ViewBag.BusLocations = await _apiService.GetBusLocationData();

				return View(model);
			}

			if (buttonClicked == "Tomorrow")
			{
				model.Date = model.Date.AddDays(1);
			}

			if (buttonClicked == "Today")
			{
				model.Date = model.Date.AddDays(-1);
			}

			_cache.Set("LastQueryModel", model, TimeSpan.FromMinutes(10)); 

			return RedirectToAction("Detail", model);
		}

		public async Task<IActionResult> Detail(QueryModel model)
		{
			var sessionResponse = await _apiService.GetJourneys(model);

			sessionResponse.Data= sessionResponse.Data.OrderBy(x=>x.Journey.Departure).ToList();

			return View(sessionResponse);

		}

		public IActionResult ClearCacheAndGoBack()
		{
			_cache.Remove("LastQueryModel");  
			return RedirectToAction("Index");  
		}
	}
}

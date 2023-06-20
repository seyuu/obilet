using Newtonsoft.Json;
using obilet_core.Models;
using System.Net.Http;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;

namespace obilet_core.Services
{
    public class ApiService : IApiService
    {
        private readonly IHttpClientWrapper _httpClientWrapper;
        private readonly IMemoryCache _cache;
        private readonly ILogger<ApiService> _logger;

        public ApiService(IHttpClientWrapper httpClientWrapper, IMemoryCache cache, ILogger<ApiService> logger)
        {
            _httpClientWrapper = httpClientWrapper;
            _cache = cache;
            _logger = logger;
        }

        private async Task<T> Post<T>(string path, object requestBody)
        {
            var requestJson = JsonConvert.SerializeObject(requestBody);
            using var content = new StringContent(requestJson, System.Text.Encoding.UTF8, "application/json");
            var response = await _httpClientWrapper.PostAsync($"https://v2-api.obilet.com/api/{path}", content);

            if (!response.IsSuccessStatusCode)
            {
                return default(T);
            }

            var responseString = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(responseString);
        }

        public async Task<GetSessionResponseModel> GetSession()
        {
            if (_cache.TryGetValue("SessionData", out GetSessionResponseModel sessionData))
            {
                return sessionData;
            }

            sessionData = await Post<GetSessionResponseModel>("client/getsession", new GetSessionRequestBody
            {
                Type = 1,
                Connection = new Connection
                {
                    IpAddress = "165.114.41.21",
                    Port = "5117"
                },
                Browser = new Browser
                {
                    Name = "Chrome",
                    Version = "47.0.0.12"
                }
            });

            _cache.Set("SessionData", sessionData, TimeSpan.FromMinutes(30));
            return sessionData;
        }

        public async Task<GetBusLocationResponseModel> GetBusLocation(string data = null)
        {
            var session = await GetSession();

            if (_cache.TryGetValue("GetBusLocation", out GetBusLocationResponseModel getBusLocation))
            {
                return getBusLocation;
            }

            getBusLocation =  await Post<GetBusLocationResponseModel>("location/getbuslocations", new GetBusLocationRequestBody
            {
                Data = data,
                DeviceSession = new DeviceSession
                {
                    SessionId = session.Data.SessionId,
                    DeviceId = session.Data.DeviceId
                },
                Date = DateTime.Now,
                Language = "tr-TR"
            });

            _cache.Set("GetBusLocation", getBusLocation, TimeSpan.FromMinutes(30));
            return getBusLocation;
        }

        public async Task<List<SelectListItem>> GetBusLocationData()
        {
            var busLocationsResponse = await GetBusLocation("aydın");

            return busLocationsResponse.Data
                                 .Where(x => x.CountryId == 8)
                                 .GroupBy(data => data.CityId)
                                 .Select(group => new SelectListItem
                                 {
                                     Value = group.Key.ToString(),
                                     Text = group.First().CityName
                                 })
                                 .ToList();
        }

        public async Task<GetJourneysResponseModel> GetJourneys(QueryModel model)
        {
            var session = await GetSession();

            var cacheKey = $"GetJourneys_{model.OriginId}_{model.DestinationId}_{model.Date}";

            if (_cache.TryGetValue(cacheKey, out GetJourneysResponseModel getJourneys))
            {
                return getJourneys;
            }

            getJourneys =  await Post<GetJourneysResponseModel>("journey/getbusjourneys", new GetJourneysRequestBody
            {
                Data = new GetJourneysData
                {
                    OriginId = model.OriginId,
                    DestinationId = model.DestinationId,
                    DepartureDate = model.Date
                },
                DeviceSession = new DeviceSession
                {
                    SessionId = session.Data.SessionId,
                    DeviceId = session.Data.DeviceId
                },
                Date = DateTime.Now,
                Language = "tr-TR"
            });

            _cache.Set(cacheKey, getJourneys, TimeSpan.FromMinutes(30));

            return getJourneys;
        }

    }
}

using Newtonsoft.Json;
using System.Collections.Generic;

public class GetBusLocationResponseModel
{
    [JsonProperty("status")]
    public string Status { get; set; }
    [JsonProperty("data")]
    public List<Data> Data { get; set; }
    [JsonProperty("message")]
    public string Message { get; set; }
    [JsonProperty("user-message")]
    public string UserMessage { get; set; }
    [JsonProperty("api-request-id")]
    public string ApiRequestId { get; set; }
    [JsonProperty("controller")]
    public string Controller { get; set; }
    [JsonProperty("client-request-id")]
    public string ClientRequestId { get; set; }
    [JsonProperty("web-correlation-id")]
    public string WebCorrelationId { get; set; }
    [JsonProperty("correlation-id")]
    public string CorrelationId { get; set; }
}

public class Data
{
    [JsonProperty("id")]
    public int Id { get; set; }
    [JsonProperty("parent-id")]
    public int? ParentId { get; set; }
    [JsonProperty("type")]
    public string Type { get; set; }
    [JsonProperty("name")]
    public string Name { get; set; }
    [JsonProperty("geo-location")]
    public GeoLocationModel GeoLocation { get; set; }
    [JsonProperty("zoom")]
    public int? Zoom { get; set; }
    [JsonProperty("tz-code")]
    public string TzCode { get; set; }
    [JsonProperty("weather-code")]
    public string WeatherCode { get; set; }
    [JsonProperty("rank")]
    public int? Rank { get; set; }
    [JsonProperty("reference-code")]
    public string ReferenceCode { get; set; }
    [JsonProperty("city-id")]
    public int? CityId { get; set; }
    [JsonProperty("reference-country")]
    public string ReferenceCountry { get; set; }
    [JsonProperty("country-id")]
    public int? CountryId { get; set; }
    [JsonProperty("keywords")]
    public string Keywords { get; set; }
    [JsonProperty("city-name")]
    public string CityName { get; set; }
    [JsonProperty("languages")]
    public string Languages { get; set; }
    [JsonProperty("country-name")]
    public string CountryName { get; set; }
    [JsonProperty("area-code")]
    public string AreaCode { get; set; }
    [JsonProperty("show-country")]
    public bool ShowCountry { get; set; }
    [JsonProperty("is-city-center")]
    public bool IsCityCenter { get; set; }
    [JsonProperty("long-name")]
    public string LongName { get; set; }
}

public class GeoLocationModel
{
    [JsonProperty("latitude")]
    public double Latitude { get; set; }
    [JsonProperty("longitude")]
    public double Longitude { get; set; }
    [JsonProperty("zoom")]
    public int? Zoom { get; set; }
}
using Newtonsoft.Json;
using System;

internal class GetJourneysRequestBody
{
    [JsonProperty("device-session")]
    public DeviceSession DeviceSession { get; set; }
    public DateTime Date { get; set; }
    public string Language { get; set; }
    public GetJourneysData Data { get; set; }
}


internal class GetJourneysData
{
    [JsonProperty("origin-id")]
    public int OriginId { get; set; }
    [JsonProperty("destination-id")]
    public int DestinationId { get; set; }
    [JsonProperty("departure-date")]
    public DateTime DepartureDate { get; set; }
}
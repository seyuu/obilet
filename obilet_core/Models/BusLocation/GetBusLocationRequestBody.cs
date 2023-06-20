using System;
using Newtonsoft.Json;

internal class GetBusLocationRequestBody
{
    [JsonProperty("data")]
    public object Data { get; set; }
    [JsonProperty("device-session")]
    public DeviceSession DeviceSession { get; set; }
    [JsonProperty("date")]
    public DateTime Date { get; set; }
    [JsonProperty("language")]
    public string Language { get; set; }
}

internal class DeviceSession
{
    [JsonProperty("session-id")]
    public string SessionId { get; set; }
    [JsonProperty("device-id")]
    public string DeviceId { get; set; }
}
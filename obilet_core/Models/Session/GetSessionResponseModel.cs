using Newtonsoft.Json;

public class GetSessionResponseModel
{
    [JsonProperty("status")]
    public string Status { get; set; }
    [JsonProperty("data")]
    public DataModel Data { get; set; }
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

public class DataModel
{
    [JsonProperty("session-id")]
    public string SessionId { get; set; }
    [JsonProperty("device-id")]
    public string DeviceId { get; set; }
    [JsonProperty("affiliate")]
    public object Affiliate { get; set; }
    [JsonProperty("device-type")]
    public int DeviceType { get; set; }
    [JsonProperty("device")]
    public object Device { get; set; }
    [JsonProperty("ip-country")]
    public string IpCountry { get; set; }
}
using Newtonsoft.Json;

public class GetSessionRequestBody
{
    public int? Type { get; set; }
    public Connection Connection { get; set; }
    public Browser Browser { get; set; }
}


public class Connection
{
    [JsonProperty("ip-address")]
    public string IpAddress { get; set; }

    public string Port { get; set; }
}

public class Browser
{
    public string Name { get; set; }
    public string Version { get; set; }
}

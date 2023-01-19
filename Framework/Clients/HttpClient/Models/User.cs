using Newtonsoft.Json;

namespace Framework.Clients.HttpClient.Models;
public class User
{
    [JsonProperty("data")]
    public Data Data { get; set; }

    [JsonProperty("support")]
    public Support Support { get; set; }
}

public class Data
{
    [JsonProperty("id")]
    public string Id { get; set; }

    [JsonProperty("email")]
    public string Email { get; set; }

    [JsonProperty("first_name")]
    public string FirstName { get; set; }

    [JsonProperty("last_name")]
    public string LastName { get; set; }

    [JsonProperty("avatar")]
    public string Avatar { get; set; }
}

public class Support
{
    [JsonProperty("url")]
    public string Url { get; set; }

    [JsonProperty("text")]
    public string Text { get; set; }
}
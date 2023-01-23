using System.Text.Json.Serialization;

namespace Framework.Clients.HttpClient.Models;
public class Post
{
    [JsonPropertyName("userId")]
    public int userId { get; set; }

    [JsonPropertyName("id")]
    public int id { get; set; }

    [JsonPropertyName("title")]
    public string title { get; set; }

    [JsonPropertyName("body")]
    public string body { get; set; }
}


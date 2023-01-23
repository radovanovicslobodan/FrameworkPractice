using RestSharp;
using Framework.Clients.HttpClient.Models;
using System.Text.Json;

namespace Framework.Clients.HttpClient;
public class PostsClient
{
    RestClient client = new RestClient("https://jsonplaceholder.typicode.com/posts/");

    public Post GetPost(int id)
    {
        RestRequest request = new RestRequest(id.ToString(), Method.Get);
        var response = client.Execute(request);

        Post postResponse = JsonSerializer.Deserialize<Post>(response.Content);

        return postResponse;
    }

    public List<Post> GetPosts()
    {
        RestRequest request = new RestRequest("", Method.Get);
        var response = client.Execute(request);

        List<Post> postsResponse = JsonSerializer.Deserialize<List<Post>>(response.Content);

        return postsResponse;
    }
}
using Framework.Clients.HttpClient.Models;
using Newtonsoft.Json;
using RestSharp;

namespace Framework.Clients.HttpClient;
public class UsersClient
{
    RestClient client = new RestClient("https://reqres.in/api/users/");

    public User GetUser(int id)
    {
        RestRequest request = new RestRequest(id.ToString(), Method.Get);
        var response = client.Execute(request);

        User userResponse = JsonConvert.DeserializeObject<User>(response.Content);

        return userResponse;
    }
}



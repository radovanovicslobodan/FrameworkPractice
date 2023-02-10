using RestSharp;

namespace Framework.Clients.HttpClient;
public abstract class BaseClient : RestClient
{
    protected string baseUrl;
    protected RestClient _client;
    public BaseClient(string baseUrl)
    {
        this.baseUrl = baseUrl;
        this._client = new RestClient();
    }
    public RestResponse Execute(RestRequest request)
    {
        Console.WriteLine("Before HTTP call");
        var response = _client.Execute(request);
        Console.WriteLine("After HTTP Call");
        return response;
    }

    public RestResponse Execute()
    {
        return null;
    }
}
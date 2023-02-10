using RestSharp;

public class ClientBase
{
    public RestClient client;

    public ClientBase(string baseUrl)
    {
        client = new RestClient(baseUrl);
    }

    public RestResponse Get(RestRequest request)
    {
        var response = client.Get(request);
        return response;
    }

    public T Get<T>(RestRequest request)
    {
        var response = client.Get<T>(request);
        return response;
    }
}
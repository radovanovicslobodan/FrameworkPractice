using HttpTracer;
using HttpTracer.Logger;
using RestSharp;
using RestSharp.Authenticators;

public class ClientBase
{
    public RestClient client;
    public Uri uri;

    public ClientBase(string baseUrl)
    {
        uri = new Uri(baseUrl);
        var options = new RestClientOptions(uri)
        {
            ConfigureMessageHandler = handler =>
                new HttpTracerHandler(handler, new ConsoleLogger(), HttpMessageParts.RequestHeaders)
        };
        client = new RestClient(options);
        client.AddCookie("Cookie", "admin123", uri.AbsolutePath, uri.Host);
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
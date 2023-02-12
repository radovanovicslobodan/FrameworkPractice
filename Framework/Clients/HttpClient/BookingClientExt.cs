using Framework.Clients.HttpClient.Models;
using HttpClient.Constants;
using HttpClient.Models;
using RestSharp;
using RestSharp.Serializers;
using HttpClient.HttpHeaderManager;
using RestSharp.Authenticators;

namespace Framework.Clients.HttpClient;

public class BookingClientExt : ClientBase
{

    public BookingClientExt(string baseUrl) : base(baseUrl)
    {
        // client.Authenticator = new JwtAuthenticator("asdfasdfasdf");
    }

    public RestResponse getBookings()
    {
        client.Authenticator = new JwtAuthenticator("asdfasdfasdf");
        client.AddCookie("TEST_COOKIE", "cookie_value123", uri.AbsolutePath, uri.Host);
        var request = new RestRequest("/booking")
            .AddHeader("Accept", "application/json");
        var response = Get(request);

        return response;
    }

    public RestResponse getBookings2()
    {
        ICollection<KeyValuePair<string, string>> headers = new List<KeyValuePair<string, string>>();
        headers.Add(new KeyValuePair<string, string>("Accept", ContentType.Json));

        var headers2 = new List<KeyValuePair<string, string>>();
        headers2.Add(Headers.AcceptJson);

        var request = new RestRequest("/booking")
            // .AddHeader("Accept", "application/json")
            .AddHeaders(headers2);
        var response = Get(request);

        return response;
    }

    public Post getPost()
    {
        var headers = new List<KeyValuePair<string, string>>();
        headers.Add(Headers.AcceptJson);

        var headers2 = HttpHeaderManager.CreateHeaders();
        headers2.Add(Headers.AcceptJson);

        // var headers3 = Constants.Constants.CreateHeaders()
        //     .Add(Constants.Constants.AcceptJson);

        var request = new RestRequest()
            // .AddHeader("Accept", ContentType.JsonAccept)
            // .AddHeaders(Framework.Clients.HttpClient.Constants.Constants.Headers.Add(Constants.Constants.AcceptJson));
            // .AddHeaders(headers);
            .AddHeaders(headers2);
        // request.RequestFormat=ContentType.JsonAccept;
        var response = Get<Post>(request);

        return response;
    }

    // public static RestResponse postBooking(string payload)
    // {
    //     var request = new RestRequest("/booking/");
    //     request.AddStringBody(payload, ContentType.Json);
    //     var response = client.ExecutePost(request);
    //     return response;
    // }
}
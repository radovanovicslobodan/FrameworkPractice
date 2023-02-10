using Framework.Clients.HttpClient.Models;
using HttpClient.Models;
using RestSharp;
using RestSharp.Serializers;

namespace Framework.Clients.HttpClient;

public class BookingClientExt : ClientBase
{

    public BookingClientExt(string baseUrl) : base(baseUrl) { }

    public RestResponse getBookings()
    {
        var request = new RestRequest("/booking")
            .AddHeader("Accept", "application/json");
        var response = Get(request);

        return response;
    }

    public RestResponse getBookings2()
    {
        var request = new RestRequest("/booking")
            .AddHeader("Accept", "application/json");
        var response = Get(request);

        return response;
    }

    public Post getPost()
    {
        var request = new RestRequest()
            .AddHeader("Accept", "application/json");
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
using HttpClient.Models;
using RestSharp;
using RestSharp.Serializers;

namespace Framework.Clients.HttpClient;

public class BookingClient
{
    static RestClient client = new RestClient("https://restful-booker.herokuapp.com/");
    // public string baseUrl;

    // public BookingClient(string baseUrl) { this.baseUrl = baseUrl}

    public static RestResponse getBookings()
    {
        var request = new RestRequest("/booking/");
        var response = client.ExecuteGet(request);

        return response;
    }

    public static RestResponse postBooking(string payload)
    {
        var request = new RestRequest("/booking/");
        request.AddStringBody(payload, ContentType.Json);
        var response = client.ExecutePost(request);
        return response;
    }
}
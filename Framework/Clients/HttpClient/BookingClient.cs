using HttpClient.Models;
using RestSharp;

namespace Framework.Clients.HttpClient;

public class BookingClient
{
    static RestClient client = new RestClient("https://restful-booker.herokuapp.com/");

    public static RestResponse getBookings()
    {
        var request = new RestRequest("/booking/");
        var response = client.ExecuteGet(request);

        return response;
    }

    public static RestResponse postBooking(Booking payload)
    {
        var request = new RestRequest("/booking/");
        request.AddObject(payload);
        var response = client.ExecutePost(request);
        return response;
    }
}
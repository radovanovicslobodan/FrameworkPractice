using System.Net;
using FluentAssertions;
using Framework.Clients.HttpClient;
using HttpClient.Models;
using RestSharp;
using RestSharp.Serializers;

namespace Tests;

public class BookingTests
{
    [Test]
    public void GetBookingsShouldReturn200()
    {
        RestResponse response = BookingClient.getBookings();
        response.StatusCode.Should().Be(HttpStatusCode.OK);
    }

    [Test]
    public void PostBookingShouldReturns201()
    {
        DateTime checkin = new DateTime(2023, 5, 5);
        DateTime checkout = new DateTime(2023, 5, 7);
        BookingDates dates = new BookingDates(checkin, checkout);

        Booking payload = new Booking(
            "John", "Doe", 100, true, dates, "Breakfast"
        );

        string body = "{\"firstname\" : \"Jim\",\"lastname\" : \"Brown\",\"totalprice\" : 111,\"depositpaid\" : true,\"bookingdates\" : {\"checkin\" : \"2018-01-01\",\"checkout\" : \"2019-01-01\"},\"additionalneeds\" : \"Breakfast\"}";

        string jsonData = "{" +
                                    "\"firstname\": \"Jim\"," +
                                    "\"lastname\": \"Brown\"," +
                                    "\"totalprice\": \"111\"," +
                                    "\"depositpaid\": \"true\"," +
                                    "\"bookingdates\": {" +
                                    "\"checkin\": \"2024-01-01\"," +
                                    "\"checkout\": \"2024-02-02\"," +
                                    "}" +
                                    "\"additionalneeds\": \"Breakfast\"" +
                                "}";

        string jsonBody = "{\n" +
               "    \"firstname\" : \"Jim\",\n" +
               "    \"lastname\" : \"Brown\",\n" +
               "    \"totalprice\" : 111,\n" +
               "    \"depositpaid\" : true,\n" +
               "    \"bookingdates\" : {\n" +
               "        \"checkin\" : \"2024-01-01\",\n" +
               "        \"checkout\" : \"2024-02-02\"\n" +
               "    },\n" +
               "    \"additionalneeds\" : \"Breakfast\"\n" +
               "}";

        // var bookingdates = new { checkin = "2018-01-01", checkout = "2019-01-01" };

        string url = "https://restful-booker.herokuapp.com/booking/";
        var client = new RestClient(url);
        var request = new RestRequest();

        var anonBody = new { firstname = "Jim", lastname = "Brown", totalprice = 111, depositpaid = true, bookingdates = new { checkin = "2024-01-01", checkout = "2024-02-02" }, additionalneeds = "Breakfast" };

        // RestResponse response = BookingClient.postBooking(anonBody);
        // request.AddJsonBody(anonBody);
        request.AddJsonBody(anonBody);

        var response = client.Post(request);
        response.StatusCode.Should().Be(HttpStatusCode.Created);
    }

    [Test]
    public void DeleteBookingShouldReturns201()
    {
        string url = "https://restful-booker.herokuapp.com/booking/8040";
        var client = new RestClient(url);
        client.AddCookie("token", "2dd042d3b1987e8", "/", "restful-booker.herokuapp.com");
        var request = new RestRequest("", Method.Delete);

        var response = client.Execute(request);
        response.StatusCode.Should().Be(HttpStatusCode.Created);
    }

    [Test]
    public void TestPostingJsonPlaceholder()
    {
        string url = "https://jsonplaceholder.typicode.com/posts";
        var client = new RestClient(url);
        var request = new RestRequest();
        var body = new { body = "This is the test body", title = "This is the test title", userId = 1 };

        request.AddJsonBody(body);
        var response = client.Post(request);

        Console.Write(response.StatusCode.ToString() + " " + response.Content.ToString());
    }
}

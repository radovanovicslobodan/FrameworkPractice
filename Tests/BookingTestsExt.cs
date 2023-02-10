using System.Net;
using FluentAssertions;
using Framework.Clients.HttpClient;
using Framework.Clients.HttpClient.Models;
using HttpClient.Models;
using RestSharp;
using RestSharp.Serializers;

namespace Tests;

public class BookingTestsExt
{
    [Test]
    public void GetBookings()
    {
        BookingClientExt clientExt = new BookingClientExt("https://restful-booker.herokuapp.com/");
        RestResponse response1 = clientExt.getBookings();
        RestResponse response2 = clientExt.getBookings2();
        response1.StatusCode.Should().Be(HttpStatusCode.OK);
        response2.StatusCode.Should().Be(HttpStatusCode.OK);
    }

    [Test]
    public void GetPost()
    {
        BookingClientExt postClient = new BookingClientExt("https://jsonplaceholder.typicode.com/posts/1");
        Post response = postClient.getPost();
        var title = response.title;
        title.Should().NotBeEmpty();
    }

    [Test]
    public void GetBookingAndPost()
    {
        BookingClientExt clientExt = new BookingClientExt("https://restful-booker.herokuapp.com/");
        BookingClientExt postClient = new BookingClientExt("https://jsonplaceholder.typicode.com/posts/1");

        RestResponse bookingsResponse = clientExt.getBookings();
        Post postResponse = postClient.getPost();
        var title = postResponse.title;

        bookingsResponse.StatusCode.Should().Be(HttpStatusCode.OK);
        title.Should().NotBeEmpty();
    }
}

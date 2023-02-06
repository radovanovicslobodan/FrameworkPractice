using System.Net;
using FluentAssertions;
using Framework.Clients.HttpClient;
using HttpClient.Models;
using RestSharp;

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

        RestResponse response = BookingClient.postBooking(payload);
        response.StatusCode.Should().Be(HttpStatusCode.Created);
    }
}

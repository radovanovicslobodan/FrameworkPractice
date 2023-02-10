using System.Net;
using Api;
using FluentAssertions;
using Payloads.Requests;

namespace Tests;

public class Booking2Tests
{
    [Test]
    public void PostBookingReturns200()
    {
        BookingPayload payload = new BookingPayload();
        payload.SetFirstname("Mary");
        payload.SetLastname("White");
        payload.SetTotalPrice(200);
        payload.SetDepositPaid(true);
        payload.SetBookingDates(new BookingDatesPayload(new DateTime(2017, 3, 31), new DateTime(2017, 4, 3)));
        payload.SetAdditionalNeeds("None");

        var response = Booking.PostBooking(payload);
        response.StatusCode.Should().Be(HttpStatusCode.OK);
    }

    [Test]
    public void PostBookingReturns200Too()
    {
        BookingPayload payload = new BookingPayload();
        payload.SetFirstname("Mary");
        payload.SetLastname("White");
        payload.SetTotalPrice(200);
        payload.SetDepositPaid(true);
        payload.SetBookingDates(new BookingDatesPayload(new DateTime(2017, 3, 31), new DateTime(2017, 4, 3)));
        payload.SetAdditionalNeeds("None");

        var response = Booking.PostBooking2(payload);
        response.StatusCode.Should().Be(HttpStatusCode.OK);
    }
}

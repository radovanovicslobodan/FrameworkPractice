namespace HttpClient.Models;

public class BookingDates
{
    public BookingDates(DateTime checkin, DateTime checkout)
    {
        this.checkin = checkin;
        this.checkout = checkout;
    }
    public DateTime checkin { get; set; }
    public DateTime checkout { get; set; }
}

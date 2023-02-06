namespace HttpClient.Models;

public class Booking
{
    public Booking(String firstname, string lastname, int totalprice, bool depositpaid, BookingDates bookingDates, string additionalneeds)
    {
        this.firstname = firstname;
        this.lastname = lastname;
        this.totalprice = totalprice;
        this.depositpaid = depositpaid;
        this.bookingdates = bookingDates;
        this.additionalneeds = additionalneeds;
    }
    public string firstname { get; set; }
    public string lastname { get; set; }
    public int totalprice { get; set; }
    public bool depositpaid { get; set; }
    public BookingDates bookingdates { get; set; }
    public string additionalneeds { get; set; }
}

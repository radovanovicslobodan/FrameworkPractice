using System.Net.Http.Headers;
using System.Text;
using System.Net;
using System.Net.Http;
// using System.Web.Http.Filters;
using Payloads.Requests;
using System.Text.Json;
using RestSharp;
using RestSharp.Serializers;

namespace Api;
public class Booking
{
    private static string _baseUrl = "https://restful-booker.herokuapp.com";

    public static HttpResponseMessage GetBookings()
    {
        var bookingUrl = _baseUrl + "/booking/";
        using (var httpClient = new HttpClient())
        {
            using (HttpRequestMessage request = new HttpRequestMessage { RequestUri = new Uri(bookingUrl), Method = HttpMethod.Get })
            {
                var response = httpClient.SendAsync(request).Result;
                CheckFor200Response(response);
                return response;
            }
        }
    }

    public static HttpResponseMessage GetBooking(int id, MediaTypeHeaderValue accept)
    {
        var bookingUrl = _baseUrl + "/booking/" + id.ToString();
        using (var httpClient = new HttpClient())
        {
            using (HttpRequestMessage request = new HttpRequestMessage { RequestUri = new Uri(bookingUrl), Method = HttpMethod.Get })
            {
                request.Headers.Add("Accept", accept.ToString());
                var response = httpClient.SendAsync(request).Result;
                CheckFor200Response(response);
                return response;
            }
        }
    }

    public static HttpResponseMessage PostBooking(BookingPayload payload)
    {
        var bookingUrl = _baseUrl + "/booking/";
        // string requestBody = JsonConvert.SerializeObject(payload);
        string requestBody = JsonSerializer.Serialize(payload);
        using (var httpClient = new HttpClient())
        {
            using (HttpRequestMessage request = new HttpRequestMessage { RequestUri = new Uri(bookingUrl), Method = HttpMethod.Post })
            {
                request.Content = new StringContent(requestBody, Encoding.UTF8, "application/json");
                //request.Headers.Add("Content-Type", "application/json");
                request.Headers.Add("Accept", "application/json");
                var response = httpClient.SendAsync(request).Result;
                CheckFor200Response(response);
                return response;
            }
        }
    }

    public static RestResponse PostBooking2(BookingPayload payload)
    {
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

        // var bookingUrl = _baseUrl + "/booking/";
        // string requestBody = JsonConvert.SerializeObject(payload);
        // string requestBody = JsonSerializer.Serialize(payload);
        RestClient client = new RestClient("https://restful-booker.herokuapp.com/");
        var request = new RestRequest("/booking/", Method.Post);
        // request.AddJsonBody(payload);
        request.AddStringBody(jsonBody, ContentType.Json);
        var response = client.Execute(request);
        return response;
    }

    public static HttpResponseMessage DeleteBooking(int id, string tokenValue)
    {
        try
        {
            var cookieContainer = new CookieContainer();
            using (var handler = new HttpClientHandler())
            {
                handler.CookieContainer = cookieContainer;
                var bookingUrl = _baseUrl + "/booking/" + id.ToString();
                using (var httpClient = new HttpClient(handler))
                {
                    using (HttpRequestMessage request = new HttpRequestMessage { RequestUri = new Uri(bookingUrl), Method = HttpMethod.Delete })
                    {
                        cookieContainer.Add(new Uri(bookingUrl), new Cookie("token", tokenValue));
                        return httpClient.SendAsync(request).Result;
                    }
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("Exception caught: " + e);
            return null;
        }
    }

    public static void CheckFor200Response(HttpResponseMessage response)
    {
        if ((int)response.StatusCode != 200)
        {
            // throw new Exception((int)response.StatusCode, "Request returned a non-200 response:" + response.RequestMessage);

            throw new Exception("Error");
        }
    }
}
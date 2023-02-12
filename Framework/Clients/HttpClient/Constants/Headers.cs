namespace HttpClient.Constants;

public class Headers
{
    // public static List<KeyValuePair<string, string>> Headers = new List<KeyValuePair<string, string>>();
    public static KeyValuePair<string, string> AcceptJson = new KeyValuePair<string, string>("Accept", "application/json");

    public static List<KeyValuePair<string, string>> CreateHeaders()
    {
        return new List<KeyValuePair<string, string>>();
    }
}

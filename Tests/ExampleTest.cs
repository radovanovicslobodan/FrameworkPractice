using Framework.Clients.HttpClient;

namespace Tests;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Test1()
    {
        UsersClient usersClient = new UsersClient();
        var user = usersClient.GetUser(1);
        Assert.AreEqual("George", user.Data.FirstName);
    }
}
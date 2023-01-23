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
        int postId = 1;
        PostsClient postsClient = new PostsClient();
        var post = postsClient.GetPost(postId);
        Assert.That(post.id, Is.EqualTo(postId));
    }
}
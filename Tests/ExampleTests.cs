using Framework.Clients.HttpClient;

namespace Tests;

public class ExampleTests
{
    PostsClient postsClient;

    [SetUp]
    public void Setup()
    {
        postsClient = new PostsClient();
    }

    [Test]
    public void TestSinglePost()
    {
        int postId = 1;
        var post = this.postsClient.GetPost(postId);
        Assert.That(post.id, Is.EqualTo(postId));
    }

    [Test]
    public void TestMultiplePosts()
    {
        var posts = this.postsClient.GetPosts();
        Assert.That(posts.Count, Is.GreaterThan(1));
    }
}
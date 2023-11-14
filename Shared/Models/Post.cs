namespace Shared.Models;

public class Post
{
    
    public string Title { get; set; }
    public string Body { get; set; }
    public User Owner { get; set; }
    public int Id { get; set; }

    public Post(string title, string body, User owner)
    {
        Title = title;
        Body = body;
        Owner = owner;
    }

}
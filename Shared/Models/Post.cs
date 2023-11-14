using System.ComponentModel.DataAnnotations;

namespace Shared.Models;

public class Post
{
    
    public string Title { get; set; }
    public string Body { get; set; }
    public string OwnerUsername { get; set; }
    public int Id { get; set; }

    public Post(string title, string body, string ownerUsername)
    {
        Title = title;
        Body = body;
        OwnerUsername = ownerUsername;
    }

    private Post(){}

}
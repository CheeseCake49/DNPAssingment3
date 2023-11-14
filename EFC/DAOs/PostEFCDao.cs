using Application.DaoInterfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Shared.Models;

namespace EFC.DAOs;

public class PostEFCDao : IPostDao
{

    private readonly DataContext _context;

    public PostEFCDao(DataContext context)
    {
        _context = context;
    }
    
    public async Task<Post> CreateAsync(Post post)
    {
        EntityEntry<Post> newPost = await _context.Posts.AddAsync(post);
        await _context.SaveChangesAsync();
        return newPost.Entity;
    }

    public async Task<IEnumerable<Post>> GetAllPostsAsync()
    {
        return _context.Posts;
    }

    public async Task<Post> GetByIdAsync(int Id)
    {
        IEnumerable<Post> posts = _context.Posts;
        return posts.First(post => post.Id == Id);
    }
}
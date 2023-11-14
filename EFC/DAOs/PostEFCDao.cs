using Application.DaoInterfaces;
using Shared.Models;

namespace EFC.DAOs;

public class PostEFCDao : IPostDao
{
    public Task<Post> CreateAsync(Post post)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Post>> GetAllPostsAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Post> GetByIdAsync(int Id)
    {
        throw new NotImplementedException();
    }
}
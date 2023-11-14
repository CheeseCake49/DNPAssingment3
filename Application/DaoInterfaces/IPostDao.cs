using Shared.Models;

namespace Application.DaoInterfaces;

public interface IPostDao
{
    Task<Post> CreateAsync(Post post);
    Task<IEnumerable<Post>> GetAllPostsAsync();
    Task<Post> GetByIdAsync(int Id);
}
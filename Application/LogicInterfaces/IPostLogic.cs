using Shared.DTOs;
using Shared.Models;

namespace Application.LogicInterfaces;

public interface IPostLogic
{
    Task<Post> CreateAsync(DTOs.PostCreationDTO postToCreate);
    Task<IEnumerable<Post>> GetAllPostsAsync();
    Task<Post> GetByIdAsync(int Id);
}
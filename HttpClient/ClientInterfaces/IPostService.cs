using Shared.DTOs;
using Shared.Models;

namespace HttpClient.ClientInterfaces;

public interface IPostService
{
    Task CreateAsync(DTOs.PostCreationDTO dto);

    Task<ICollection<Post>> GetPostsAsync(string? userName, string? title, string? body);
    Task<Post> GetPostAsync(int id);
}
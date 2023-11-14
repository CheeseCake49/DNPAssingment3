using Shared.DTOs;
using Shared.Models;

namespace HttpClient.ClientInterfaces;

public interface IPostService
{
    Task CreateAsync(DTOs.PostCreationDTO dto);

    Task<ICollection<Post>> GetPostAsync(string? userName, string? title, string? body);
}
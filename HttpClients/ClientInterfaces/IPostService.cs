using Shared.DTOs;
using Shared.Models;

namespace HttpClients.ClientInterfaces;

public interface IPostService
{
    Task CreateAsync(DTOs.PostCreationDTO dto);

    Task<ICollection<Post>> GetAsync(string? userName, string? title, string? body);
}
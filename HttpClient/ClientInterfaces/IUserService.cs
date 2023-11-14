using Shared.DTOs;
using Shared.Models;

namespace HttpClient.ClientInterfaces;

public interface IUserService
{
    Task<User> CreateAsync(DTOs.UserCreationDTO dto);
    Task<IEnumerable<User>> GetUsersAsync(string? usernameContains = null);
}
using Shared.DTOs;
using Shared.Models;

namespace HttpClients.ClientInterfaces;

public interface IUserService
{
    Task<User> Create(DTOs.UserCreationDTO dto);
    Task<IEnumerable<User>> GetUsers(string? usernameContains = null);
}
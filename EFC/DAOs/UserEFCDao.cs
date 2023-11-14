using Application.DaoInterfaces;
using Shared.Models;

namespace EFC.DAOs;

public class UserEFCDao : IUserDao
{
    public Task<User> CreateAsync(User user)
    {
        throw new NotImplementedException();
    }

    public Task<User?> GetByUsernameAsync(string username)
    {
        throw new NotImplementedException();
    }
}
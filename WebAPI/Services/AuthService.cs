using System.ComponentModel.DataAnnotations;
using Application.DaoInterfaces;
using Shared.Models;

namespace WebAPI.Services;

public class AuthService : IAuthService
{
    private readonly IUserDao _userDao;
    private IEnumerable<User> users;

    public AuthService(IUserDao userDao)
    {
        _userDao = userDao;
    }
    
    public async Task<User> ValidateUser(string username, string password)
    {
        users = await _userDao.GetAllUsersAsync();
        User? existingUser = users.FirstOrDefault(u => 
            u.Username.Equals(username, StringComparison.OrdinalIgnoreCase));
        
        if (existingUser == null)
        {
            throw new Exception("User not found");
        }

        if (!existingUser.Password.Equals(password))
        {
            throw new Exception("Password mismatch");
        }

        return existingUser;
    }
}
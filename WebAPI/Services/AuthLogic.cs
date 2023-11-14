using System.ComponentModel.DataAnnotations;
using Shared.Models;

namespace WebAPI.Services;

public class AuthLogic : IAuthLogic
{
    private readonly IList<User> users = new List<User>
    {
        new User
        {
            Username = "trmo", Password = "onetwo3FOUR"
        }
    };

    public Task<User> ValidateUser(string username, string password)
    {
        User? existingUser = users.FirstOrDefault(u => 
            u.Username.Equals(username, StringComparison.OrdinalIgnoreCase));

        if (existingUser == null)
        {
            throw new Exception("User not found");
        }

        if (!existingUser.Password.Equals(password))
        {
            throw new Exception("Wrong password");
        }

        return Task.FromResult(existingUser);
    }

    public Task RegisterUser(User user)
    {
        if (string.IsNullOrEmpty(user.Username))
        {
            throw new ValidationException("Username cannot be null");
        }

        if (string.IsNullOrEmpty(user.Password))
        {
            throw new ValidationException("Password cannot be null");
        }
        
        users.Add(user);
        return Task.CompletedTask;
    }
}
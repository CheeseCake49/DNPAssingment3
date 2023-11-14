using Application.DaoInterfaces;
using Application.LogicInterfaces;
using Shared.DTOs;
using Shared.Models;

namespace Application.Logic;

public class UserLogic : IUserLogic
{

    private readonly IUserDao _userDao;

    public UserLogic(IUserDao userDao)
    {
        _userDao = userDao;
    }
    public async Task<User> CreateAsync(DTOs.UserCreationDTO userToCreate)
    {
        User? existing = await _userDao.GetByUsernameAsync(userToCreate.Username);
        if (existing != null)
            throw new Exception("Username already taken");

        ValidateData(userToCreate);
        User toCreate = new User(userToCreate.Username, userToCreate.Password);

        return await _userDao.CreateAsync(toCreate);
    }

    private static void ValidateData(DTOs.UserCreationDTO userToCreate)
    {
        string username = userToCreate.Username;

        if (username.Length < 3)
            throw new Exception("Username must be at least 3 characters");

        if (username.Length > 15)
            throw new Exception("Username must be less than 16 characters");
    }
}
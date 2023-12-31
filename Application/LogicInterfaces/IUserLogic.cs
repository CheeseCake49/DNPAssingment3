﻿using Shared.DTOs;
using Shared.Models;

namespace Application.LogicInterfaces;

public interface IUserLogic
{
    Task<User> CreateAsync(DTOs.UserCreationDTO userToCreate);
    Task<IEnumerable<User>> GetAllUsersAsync();
}
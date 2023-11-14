using Application.DaoInterfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Shared.Models;

namespace EFC.DAOs;

public class UserEFCDao : IUserDao
{

    private readonly DataContext _context;

    public UserEFCDao(DataContext context)
    {
        _context = context;
    }
    
    public async Task<User> CreateAsync(User user)
    {
        EntityEntry<User> newUser = await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();
        return newUser.Entity;
    }

    public async Task<User?> GetByUsernameAsync(string username)
    {
        User? existing = await _context.Users.FirstOrDefaultAsync(u =>
            u.Username.ToLower().Equals(username.ToLower()));
        return existing;
    }
}
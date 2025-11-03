using App.Domain.User.Interfaces;
using App.Infrastructure.Data;
using App.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace App.Infrastructure.Users.Repositories;

public class UserRepository : IUserRepository
{
    private readonly AppDbContext _context;

    public UserRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(User user)
    {
        await _context.Users.AddAsync(user);
    }

    public async Task<IEnumerable<User>> GetAllAsync()
    {
        return await _context.Users
            .Include(u => u.UserRoles)
            .ThenInclude(ur => ur.Role) 
            .AsNoTracking()
            .ToListAsync();
    }
}
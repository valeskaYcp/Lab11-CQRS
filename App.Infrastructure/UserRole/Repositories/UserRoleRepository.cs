using App.Domain.UserRole.Interfaces;
using App.Infrastructure.Data;
using App.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace App.Infrastructure.UserRole.Repositories;

public class UserRoleRepository : IUserRoleRepository
{
    private readonly AppDbContext _context;

    public UserRoleRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task AssignRoleAsync(Guid userId, Guid roleId)
    {
        bool exists = await _context.UserRoles
            .AnyAsync(ur => ur.UserId == userId && ur.RoleId == roleId);

        if (!exists)
        {
            var userRole = new Models.UserRole
            {
                UserId = userId,
                RoleId = roleId,
                AssignedAt = DateTime.UtcNow
            };

            await _context.UserRoles.AddAsync(userRole);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<IEnumerable<Models.UserRole>> GetAllAsync()
    {
        return await _context.UserRoles
            .Include(ur => ur.User)
            .Include(ur => ur.Role)
            .ToListAsync();
    }

    public async Task<Models.UserRole?> GetByIdsAsync(Guid userId, Guid roleId)
    {
        return await _context.UserRoles
            .Include(ur => ur.User)
            .Include(ur => ur.Role)
            .FirstOrDefaultAsync(ur => ur.UserId == userId && ur.RoleId == roleId);
    }

    public async Task RemoveRoleAsync(Guid userId, Guid roleId)
    {
        var userRole = await GetByIdsAsync(userId, roleId);
        if (userRole != null)
        {
            _context.UserRoles.Remove(userRole);
            await _context.SaveChangesAsync();
        }
    }
}
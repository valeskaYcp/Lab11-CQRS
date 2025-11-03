namespace App.Domain.UserRole.Interfaces;

public interface IUserRoleRepository
{
    Task AssignRoleAsync(Guid userId, Guid roleId);
    Task<IEnumerable<Infrastructure.Models.UserRole>> GetAllAsync();
    Task<Infrastructure.Models.UserRole?> GetByIdsAsync(Guid userId, Guid roleId);
    Task RemoveRoleAsync(Guid userId, Guid roleId);
}
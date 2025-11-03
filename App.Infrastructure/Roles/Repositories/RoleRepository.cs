using App.Domain.Roles.Interfaces;
using App.Infrastructure.Data;
using App.Infrastructure.Models;

namespace App.Infrastructure.Roles.Repositories;

public class RoleRepository : GenericRepository<Role>, IRoleRepository
{
    public RoleRepository(AppDbContext context) : base(context) { }
}
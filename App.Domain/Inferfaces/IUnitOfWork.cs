using App.Domain.Response.Interfaces;
using App.Domain.Tickets.Interfaces;
using App.Domain.User.Interfaces;
using App.Domain.UserRole.Interfaces;

namespace App.Domain.Roles.Interfaces;

public interface IUnitOfWork
{
    IRoleRepository Roles { get; }
    IUserRepository Users { get; }
    IUserRoleRepository UserRoles { get; }
    IResponseRepository Responses { get; }
    ITicketRepository TicketRepository { get; }
    Task<int> CompleteAsync();
    Task<int> SaveChangesAsync();
}
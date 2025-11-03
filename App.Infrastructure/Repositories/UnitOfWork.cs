using App.Domain.Response.Interfaces;
using App.Domain.Roles.Interfaces;
using App.Domain.User.Interfaces;
using App.Domain.UserRole.Interfaces;
using App.Domain.Tickets.Interfaces; 
using App.Infrastructure.Data;
using App.Infrastructure.Roles.Repositories;
using App.Infrastructure.UserRole.Repositories;
using App.Infrastructure.Users.Repositories;
using App.Infrastructure.Tickets.Repositories; 

namespace App.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            Roles = new RoleRepository(_context);
            Users = new UserRepository(_context);
            UserRoles = new UserRoleRepository(_context);
            TicketRepository = new TicketRepository(_context); 
        }

        public IRoleRepository Roles { get; }
        public IUserRepository Users { get; }
        public IUserRoleRepository UserRoles { get; }
        public ITicketRepository TicketRepository { get; } 
        
        public IResponseRepository Responses { get;}

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
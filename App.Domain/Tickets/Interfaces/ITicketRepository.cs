using App.Infrastructure.Models;

namespace App.Domain.Tickets.Interfaces;

public interface ITicketRepository
{
    Task AddAsync(Ticket ticket);
    Task<IEnumerable<Ticket>> GetAllAsync();
    Task<Ticket?> GetByIdAsync(Guid ticketId);
    Task UpdateAsync(Ticket ticket);
    Task RemoveAsync(Guid ticketId);
}
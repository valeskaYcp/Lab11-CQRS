using App.Domain.Tickets.Interfaces;
using App.Infrastructure.Data;
using App.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace App.Infrastructure.Tickets.Repositories;

public class TicketRepository : ITicketRepository
{
    private readonly AppDbContext _context;

    public TicketRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Ticket ticket)
    {
        await _context.Tickets.AddAsync(ticket);
    }

    public async Task<IEnumerable<Ticket>> GetAllAsync()
    {
        return await _context.Tickets
            .Include(t => t.User)
            .ToListAsync();
    }

    public async Task<Ticket?> GetByIdAsync(Guid ticketId)
    {
        return await _context.Tickets
            .Include(t => t.User)
            .FirstOrDefaultAsync(t => t.TicketId == ticketId);
    }

    public async Task UpdateAsync(Ticket ticket)
    {
        _context.Tickets.Update(ticket);
    }

    public async Task RemoveAsync(Guid ticketId)
    {
        var ticket = await GetByIdAsync(ticketId);
        if (ticket != null)
            _context.Tickets.Remove(ticket);
    }
}

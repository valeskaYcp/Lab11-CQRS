using ResponseModel = App.Infrastructure.Models.Response;
using App.Domain.Response.Interfaces;
using App.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace App.Infrastructure.Response.Repositories;

public class ResponseRepository : IResponseRepository
{
    private readonly AppDbContext _context;

    public ResponseRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(ResponseModel response)
    {
        await _context.Responses.AddAsync(response);
    }

    public async Task<IEnumerable<ResponseModel>> GetAllAsync()
    {
        return await _context.Responses
            .Include(r => r.Responder)
            .Include(r => r.Ticket)
            .ToListAsync();
    }

    public async Task<ResponseModel?> GetByIdAsync(Guid responseId)
    {
        return await _context.Responses
            .Include(r => r.Responder)
            .Include(r => r.Ticket)
            .FirstOrDefaultAsync(r => r.ResponseId == responseId);
    }

    public async Task<IEnumerable<ResponseModel>> GetAllByTicketIdAsync(Guid ticketId)
    {
        return await _context.Responses
            .Include(r => r.Responder)
            .Include(r => r.Ticket)
            .Where(r => r.TicketId == ticketId)
            .ToListAsync();
    }

    public async Task UpdateAsync(ResponseModel response)
    {
        _context.Responses.Update(response);
    }

    public async Task RemoveAsync(Guid responseId)
    {
        var response = await GetByIdAsync(responseId);
        if (response != null)
            _context.Responses.Remove(response);
    }
}
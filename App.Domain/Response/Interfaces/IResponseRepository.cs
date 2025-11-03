namespace App.Domain.Response.Interfaces;

using ResponseModel = App.Infrastructure.Models.Response;

public interface IResponseRepository
{
    Task AddAsync(ResponseModel response);
    Task<IEnumerable<ResponseModel>> GetAllAsync();
    Task<ResponseModel?> GetByIdAsync(Guid responseId);
    Task<IEnumerable<ResponseModel>> GetAllByTicketIdAsync(Guid ticketId);
    Task UpdateAsync(ResponseModel response);
    Task RemoveAsync(Guid responseId);
}
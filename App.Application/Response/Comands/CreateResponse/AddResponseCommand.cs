using MediatR;

namespace App.Application.Response.Comands.CreateResponse;

public class AddResponseCommand : IRequest<Guid>
{
    public Guid TicketId { get; set; }
    public Guid ResponderId { get; set; }
    public string Message { get; set; } = null!;
}
using App.Domain.Roles.Interfaces;
using App.Domain.Tickets.Interfaces;
using App.Infrastructure.Models;
using MediatR;

namespace App.Application.Tickets.Comands.CreateTickets;

public class AddTicketCommandHandler : IRequestHandler<AddTicketCommand, Guid>
{
    private readonly ITicketRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public AddTicketCommandHandler(ITicketRepository repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Guid> Handle(AddTicketCommand request, CancellationToken cancellationToken)
    {
        var ticket = new Ticket
        {
            TicketId = Guid.NewGuid(),
            UserId = request.UserId,
            Title = request.Title,
            Description = request.Description,
            Status = "abierto",
            CreatedAt = DateTime.UtcNow
        };

        await _repository.AddAsync(ticket);
        await _unitOfWork.SaveChangesAsync();

        return ticket.TicketId;
    }
}
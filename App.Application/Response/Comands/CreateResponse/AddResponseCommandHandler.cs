using App.Domain.Response.Interfaces;
using MediatR;
using App.Domain.Roles.Interfaces;

namespace App.Application.Response.Comands.CreateResponse;

public class AddResponseCommandHandler : IRequestHandler<AddResponseCommand, Guid>
{
    private readonly IResponseRepository _responseRepository;
    private readonly IUnitOfWork _unitOfWork;

    public AddResponseCommandHandler(IResponseRepository responseRepository, IUnitOfWork unitOfWork)
    {
        _responseRepository = responseRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Guid> Handle(AddResponseCommand request, CancellationToken cancellationToken)
    {
        var response = new Infrastructure.Models.Response
        {
            ResponseId = Guid.NewGuid(),
            TicketId = request.TicketId,
            ResponderId = request.ResponderId,
            Message = request.Message,
            CreatedAt = DateTime.UtcNow
        };

        await _responseRepository.AddAsync(response);
        await _unitOfWork.SaveChangesAsync();

        return response.ResponseId;
    }
}
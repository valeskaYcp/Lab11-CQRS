using App.Application.UserRoles.Comands.CreateUserRoles;
using App.Domain.Roles.Interfaces;
using MediatR;

namespace App.Application.UserRoles.Queries;

public class AssignRoleCommandHandler : IRequestHandler<AssignRoleCommand, bool>
{
    private readonly IUnitOfWork _unitOfWork;

    public AssignRoleCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<bool> Handle(AssignRoleCommand request, CancellationToken cancellationToken)
    {
        await _unitOfWork.UserRoles.AssignRoleAsync(request.UserId, request.RoleId);
        await _unitOfWork.CompleteAsync();
        return true;
    }
}
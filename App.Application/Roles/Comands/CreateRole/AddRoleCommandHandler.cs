using App.Domain.Roles.Interfaces;
using App.Infrastructure.Models;
using MediatR;

namespace App.Application.Roles.Comands.CreateRole;

internal sealed class AddRoleCommandHandler : IRequestHandler<AddRoleCommand, Guid>
{
    private readonly IUnitOfWork _unitOfWork;

    public AddRoleCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Guid> Handle(AddRoleCommand request, CancellationToken cancellationToken)
    {
        var role = new Role
        {
            RoleId = Guid.NewGuid(),
            RoleName = request.RoleName
        };

        _unitOfWork.Roles.Add(role);
        await _unitOfWork.CompleteAsync();
        return role.RoleId;
    }
}
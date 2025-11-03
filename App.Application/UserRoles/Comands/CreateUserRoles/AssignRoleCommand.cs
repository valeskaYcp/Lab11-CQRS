using MediatR;
using System;

namespace App.Application.UserRoles.Comands.CreateUserRoles
{
    public record AssignRoleCommand(Guid UserId, Guid RoleId) : IRequest<bool>;
}
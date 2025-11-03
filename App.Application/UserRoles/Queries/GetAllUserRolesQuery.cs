using App.Application.UserRoles.DTOs;
using MediatR;
using System.Collections.Generic;

namespace App.Application.UserRoles.Comands.CreateUserRoles
{
    public record GetAllUserRolesQuery() : IRequest<IEnumerable<UserRoleDto>>;
}
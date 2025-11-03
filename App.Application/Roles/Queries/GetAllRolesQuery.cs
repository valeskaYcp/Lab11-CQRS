using App.Application.Roles.DTOs;
using MediatR;

namespace App.Application.Roles.Queries
{
    public record GetAllRolesQuery() : IRequest<IEnumerable<RoleDto>>;
}
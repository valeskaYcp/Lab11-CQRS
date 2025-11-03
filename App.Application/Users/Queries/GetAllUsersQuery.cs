using App.Application.Users.DTOs;
using MediatR;

namespace App.Application.Users.Queries
{
    public class GetAllUsersQuery : IRequest<IEnumerable<UserDto>>
    {
    }
}
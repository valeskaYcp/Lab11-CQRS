using App.Domain.Roles.Interfaces;
using App.Domain.User.Interfaces;
using App.Infrastructure.Models;
using MediatR;

namespace App.Application.Users.Comands.CreateUser;

public class AddUserCommandHandler : IRequestHandler<AddUserCommand, Guid>
{
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;

    public AddUserCommandHandler(IUserRepository userRepository, IUnitOfWork unitOfWork)
    {
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Guid> Handle(AddUserCommand request, CancellationToken cancellationToken)
    {
        var user = new User
        {
            UserId = Guid.NewGuid(),
            Username = request.UserName,
            Email = request.Email,
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password),
            CreatedAt = DateTime.UtcNow
        };

        user.UserRoles.Add(new UserRole
        {
            UserId = user.UserId,
            RoleId = request.RoleId
        });

        await _userRepository.AddAsync(user);
        await _unitOfWork.SaveChangesAsync();

        return user.UserId;
    }
}


namespace App.Domain.User.Interfaces;

public interface IUserRepository
{
    Task AddAsync(Infrastructure.Models.User user);
    Task<IEnumerable<Infrastructure.Models.User>> GetAllAsync();
}

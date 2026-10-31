namespace TaxFlow.Application.Interfaces;
using TaxFlow.Domain.Entities;

public interface IUserRepository
{
    Task<User?> GetByEmailAsync(string email);
    Task<User> CreateAsync(User user);
    Task<bool> ExistsByEmailAsync(string email);
}
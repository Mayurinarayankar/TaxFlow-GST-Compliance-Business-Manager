namespace TaxFlow.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using TaxFlow.Application.Interfaces;
using TaxFlow.Domain.Entities;
using TaxFlow.Infrastructure.Data;

public class UserRepository : IUserRepository
{
    private readonly AppDbContext _context;
    public UserRepository(AppDbContext context) => _context = context;

    public async Task<User?> GetByEmailAsync(string email) 
        => await _context.Users.FirstOrDefaultAsync(u => u.Email == email);

    public async Task<User> CreateAsync(User user)
    {
        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();
        return user;
    }

    public async Task<bool> ExistsByEmailAsync(string email) 
        => await _context.Users.AnyAsync(u => u.Email == email);
}
using DeadlineMissed.UserService.Domain.Entities;
using DeadlineMissed.UserService.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace DeadlineMissed.UserService.Infrastructure.Repositories;

public class UserRepository:IUserRepository
{
    private readonly AppDbContext _context;

    public UserRepository(AppDbContext context) => _context = context;

    public async Task<List<User>> GetAllAsync() => await _context.Users.ToListAsync();

    public async Task<User> GetByIdAsync(int id) => await _context.Users.FindAsync(id);

    public async Task AddAsync(User user)
    {
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
    }
    public async Task<List<User>> GetByIdsAsync(List<int> ids) => await _context.Users.Where(u => ids.Contains(u.Id)).ToListAsync();
}

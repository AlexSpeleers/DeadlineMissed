using DeadlineMissed.UserService.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DeadlineMissed.UserService.Infrastructure.Data;

public class AppDbContext: DbContext
{
    public DbSet<User> Users { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
}

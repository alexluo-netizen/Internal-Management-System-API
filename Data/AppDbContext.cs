using Microsoft.EntityFrameworkCore;
using InternalManagementSystem.Api.Models;

namespace InternalManagementSystem.Api.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Product> Products => Set<Product>();
}
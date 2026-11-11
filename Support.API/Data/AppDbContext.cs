using Microsoft.EntityFrameworkCore;
using Support.API.Models;

namespace Support.API.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Order> Orders => Set<Order>();
    public DbSet<Incident> Incidents => Set<Incident>();
}
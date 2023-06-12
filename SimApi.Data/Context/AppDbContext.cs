using Microsoft.EntityFrameworkCore;
namespace SimApi.Data.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
    
    public DbSet<Transaction> Transactions { get; set; }
}
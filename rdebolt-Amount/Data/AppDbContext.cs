using rdebolt_Amount.Models;
using Microsoft.EntityFrameworkCore;

namespace rdebolt_Amount.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        
        public DbSet<Business> Businesses { get; set; }
        public DbSet<Demographic> Demographics { get; set; }
        public DbSet<Loan> Loan { get; set; }

    }
}

using System.Reflection;
using Microsoft.EntityFrameworkCore;
using UpskillingTask.Domain.Models;

namespace UpskillingTask.Persistence.Data
{
    public class UpskillingTaskDbContext : DbContext
    {
        public UpskillingTaskDbContext(DbContextOptions<UpskillingTaskDbContext> options) : base(options)
        {
            
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
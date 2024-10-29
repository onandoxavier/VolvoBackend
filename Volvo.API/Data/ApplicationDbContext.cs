using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Volvo.API.Domain.Entities;

namespace Volvo.API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Truck> Trucks { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.HasDefaultSchema("db");

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}

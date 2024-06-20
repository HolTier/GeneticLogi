using Microsoft.EntityFrameworkCore;
using GeneticLogi_Backend.Models;

namespace GeneticLogi_Backend.Data
{
    public class GeneticLogiDbContext : DbContext
    {
        public GeneticLogiDbContext(DbContextOptions<GeneticLogiDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Package> Packages { get; set; }
        public DbSet<Delivery> Deliveries { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Models.Route> Routes { get; set; }
        public DbSet<RouteStop> RouteStops { get; set; }
        public DbSet<Truck> Trucks { get; set; }
        public DbSet<RouteDelivery> RouteDeliveries { get; set; }
        public DbSet<OrderDelivery> OrderDeliveries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .Property(u => u.Password)
                .HasMaxLength(128);

            modelBuilder.Entity<RouteDelivery>()
                .HasKey(rd => new { rd.RouteId, rd.DeliveryId }); // Define composite primary key

            modelBuilder.Entity<OrderDelivery>()
                .HasKey(od => new { od.OrderId, od.DeliveryId }); // Define composite primary key
        }
    }
}

using Microsoft.EntityFrameworkCore;
using DBServer.Models;

namespace DBServer.Models
{
    public class WarehouseContext : DbContext
    {
        public WarehouseContext(DbContextOptions<WarehouseContext> options)
            : base(options)
        { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Supply> Supplies { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Unit> Units { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Shipment> Shipments { get; set; }
        public DbSet<OrderProduct> OrderProducts { get; set; }
        public DbSet<ShipmentProduct> ShipmentProducts { get; set; }
        public DbSet<SupplyProduct> SupplyProducts { get; set; }
        public DbSet<Category> Category { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Составные ключи
            modelBuilder.Entity<OrderProduct>()
                .HasKey(e => new { e.OrderId, e.ProductId });
            modelBuilder.Entity<SupplyProduct>()
                .HasKey(e => new { e.SupplyId, e.ProductId });
            modelBuilder.Entity<ShipmentProduct>()
                .HasKey(e => new { e.ShipmentId, e.ProductId });

            // Правка каскадного удаления
            modelBuilder.Entity<Unit>()
                .HasMany(u => u.Products)
                .WithOne(p => p.Unit)
                .OnDelete(DeleteBehavior.SetNull);
            modelBuilder.Entity<Category>()
                .HasMany(c => c.Products)
                .WithOne(p => p.Category)
                .OnDelete(DeleteBehavior.SetNull);
            modelBuilder.Entity<Position>()
                .HasMany(p => p.Employees)
                .WithOne(e => e.Position)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    Login = "admin",
                    Password = "admin",
                    Permissions = UserPermissions.Read | UserPermissions.Write | UserPermissions.Delete | UserPermissions.ManageEmployees | UserPermissions.ManageUsers
                }
            );
        }
    }
}

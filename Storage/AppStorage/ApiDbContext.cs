using Core.Base.DataBase.Entities;
using Core.Base.Models.Enums;
using Storage.AppStorage.Configuration;
using Storage.AppStorage.Maps;
using Microsoft.EntityFrameworkCore;

namespace Storage.AppStorage;

public class ApiDbContext : DbContext
{
    public ApiDbContext(DbContextOptions<ApiDbContext> options)
        : base(options)
    {
        // Database.EnsureCreated();
    }

    public DbSet<ProductEntity> Products { get; set; }
    public DbSet<OrderEntity> Orders { get; set; }
    public DbSet<ShipmentEntity> Shipments { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasPostgresExtension("uuid-ossp");
        var productConfiguration = new ProductConfiguration();
        // new ProductMap(modelBuilder.Entity<ProductEntity>());
        // new OrderMap(modelBuilder.Entity<OrderEntity>());
        // new ShipmentMap(modelBuilder.Entity<ShipmentEntity>());
        // modelBuilder.Entity<ProductEntity>().HasData(new ProductEntity { Id = 1, Description = "Desc", Name = "Tit" });
        // modelBuilder.Entity<OrderEntity>().HasData(new OrderEntity { Id = 1, Description = "Order-Desc", OrderType = OrderType.Product });
        // modelBuilder.Entity<ShipmentEntity>().HasData(new ShipmentEntity { Id = 1, Description = "Order-Desc", Name = "Order-Tit" });
        modelBuilder.ApplyConfiguration(productConfiguration);
        base.OnModelCreating(modelBuilder);
    }
}
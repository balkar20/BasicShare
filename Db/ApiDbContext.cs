using Core.Base.DataBase.Entities;
using Data.Db.Maps;
using Microsoft.EntityFrameworkCore;

namespace Data.Db;

public class ApiDbContext : DbContext
{
    public ApiDbContext(DbContextOptions<ApiDbContext> options)
        : base(options)
    {
        
    }
    public DbSet<ProductEntity> Products { get; set; }
    public DbSet<OrderEntity> Orders { get; set; }
    public DbSet<ShipmentEntity> Shipments { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        new ProductMap(modelBuilder.Entity<ProductEntity>());
        new OrderMap(modelBuilder.Entity<OrderEntity>());
        new ShipmentMap(modelBuilder.Entity<ShipmentEntity>());
        modelBuilder.Entity<ProductEntity>().HasData(new ProductEntity { Id = 1, Description = "Desc", Name = "Tit" });
        modelBuilder.Entity<OrderEntity>().HasData(new OrderEntity { Id = 1, Description = "Order-Desc", Name = "Order-Tit" });
        modelBuilder.Entity<ShipmentEntity>().HasData(new ShipmentEntity { Id = 1, Description = "Order-Desc", Name = "Order-Tit" });
    }
}
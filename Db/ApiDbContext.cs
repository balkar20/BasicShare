using Core.Base.DataBase.Entities;
using Db.Maps;
using Microsoft.EntityFrameworkCore;

namespace Db;

public class ApiDbContext : DbContext
{
    public ApiDbContext(DbContextOptions<ApiDbContext> options)
        : base(options)
    {
        
    }
    public DbSet<ProductEntity> Products { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        new ProductMap(modelBuilder.Entity<ProductEntity>());
        new OrderMap(modelBuilder.Entity<OrderEntity>());
        modelBuilder.Entity<ProductEntity>().HasData(new ProductEntity { Id = 1, Description = "Desc", Name = "Tit" });
        modelBuilder.Entity<OrderEntity>().HasData(new OrderEntity { Id = 1, Description = "Order-Desc", Name = "Order-Tit" });
    }
}
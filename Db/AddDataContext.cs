using Db.Maps;
using Microsoft.EntityFrameworkCore;

namespace Db;

public class ApiDbContext : DbContext
{
    public ApiDbContext(DbContextOptions<ApiDbContext> options)
        : base(options)
    {
        
    }
    public DbSet<Product> Products { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        new BlogMap(modelBuilder.Entity<Product>());
        modelBuilder.Entity<Product>().HasData(new Product { Id = 1, Description = "Desc", Name = "Tit" });
        //base.OnModelCreating(modelBuilder);
        //Database.EnsureCreated();
        //Database.Migrate();
    }
}
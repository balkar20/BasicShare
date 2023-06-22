using Core.Base.DataBase.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Db.Configuration;

public class ProductConfiguration: IEntityTypeConfiguration<ProductEntity>
{
    private readonly List<string> productNames = new List<string>()
    {
        //1. Nastya todo - order
        "BestStuff",
        "Lolly",
        "Candy",
        "Picks" +
        "Sex" +
        "oMG" +
        "Lofty",
        "Toffy",
        "Fuckas",
        "Grep",
    };
    public List<ProductEntity> Products { get; set; } = new List<ProductEntity>();
    public void Configure(EntityTypeBuilder<ProductEntity> builder)
    {
        builder.HasKey(p => p.Id);
        builder.Property(prop => prop.Id)
            .UseIdentityColumn();

        int i  = 1;
        foreach (var productName in productNames)
        {
            var product = new ProductEntity
            {
                Id = i,
                Name = productName,
                Description = $"Description of {productName}",
            };

            i++;
            
            // builder.HasData(product);
            Products.Add(product);
        }

        builder.HasData(Products);
    }
}
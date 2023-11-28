using Core.Base.DataBase.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.ValueGeneration;

namespace Storage.AppStorage.Configuration;

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
        // builder.HasKey(p => p.Id);
        builder.Property(prop => prop.Id);
            // .ValueGeneratedOnAdd();
            // .HasDefaultValueSql("uuid-ossp()");
        // builder.Property(e => e.Id).Metadata.SetBeforeSaveBehavior(PropertySaveBehavior.Ignore); // Set BeforeSaveBehavior to Ignore to avoid seeding issues
            // .IsRequired(false);
            // .HasValueGenerator<GuidValueGenerator>();

        int i  = 1;
        foreach (var productName in productNames)
        {
            var product = new ProductEntity
            {
                Id = Guid.NewGuid(),
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
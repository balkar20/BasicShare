using Core.Base.DataBase.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Db.Maps;

#pragma warning disable CS1591
public class ProductMap
{
    public ProductMap(EntityTypeBuilder<ProductEntity> entityBuilder)
    {
        entityBuilder.HasKey(x => x.Id);
        entityBuilder.ToTable("product");

        entityBuilder.Property(x => x.Id).HasColumnName("id");
        entityBuilder.Property(x => x.Name).HasColumnName("name");
        entityBuilder.Property(x => x.Description).HasColumnName("description");
    }
}
#pragma warning restore CS1591
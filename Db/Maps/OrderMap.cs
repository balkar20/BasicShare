using Core.Base.DataBase.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Db.Maps;

#pragma warning disable CS1591
public class OrderMap
{
    public OrderMap(EntityTypeBuilder<OrderEntity> entityBuilder)
    {
        entityBuilder.HasKey(x => x.Id);
        entityBuilder.ToTable("order");

        entityBuilder.Property(x => x.Id).HasColumnName("id");
        entityBuilder.Property(x => x.Name).HasColumnName("name");
        entityBuilder.Property(x => x.Description).HasColumnName("description");
    }
}
#pragma warning restore CS1591
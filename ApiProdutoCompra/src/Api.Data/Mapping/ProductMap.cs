using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data.Mapping
{
    public class ProductMap : IEntityTypeConfiguration<ProductEntity>
    {
        public void Configure(EntityTypeBuilder<ProductEntity> builder)
        {
            builder.ToTable("Product");

            builder.HasKey(u => u.Id);

            builder.Property(u => u.nome)
                   .IsRequired()
                   .HasMaxLength(60);

            builder.Property(u => u.valor_unitario);
            builder.Property(u => u.qtde_estoque);
        }
    }
}

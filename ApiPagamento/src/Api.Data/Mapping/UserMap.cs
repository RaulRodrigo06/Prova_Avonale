using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data.Mapping
{
    public class UserMap : IEntityTypeConfiguration<PagamentoEntity>
    {
        public void Configure(EntityTypeBuilder<PagamentoEntity> builder)
        {
            builder.ToTable("Pagamento");

            builder.HasKey(u => u.valor);
            //builder.Property(u => u.Cartao);
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TechChallenge.src.Core.Domain.Entities;

namespace TechChallenge.src.Adapters.Driven.Infra.Mappings
{
    public class PedidoMapping : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(EntityTypeBuilder<Pedido> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.NumeroPedido)
                .IsRequired()
                .HasColumnType("varchar(10)");

            // 1 : 1 => Pedido : IdentificacaoPedido
            builder.HasOne(f => f.IdentificacaoPedido)
                .WithOne(e => e.Pedido);

            builder.ToTable("Pedido");
        }
    }
}
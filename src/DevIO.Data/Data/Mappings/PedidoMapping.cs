using DevIO.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevIO.Data.Data.Mappings
{
    public class PedidoMapping : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(EntityTypeBuilder<Pedido> builder)
        {
            builder.ToTable(nameof(Pedido));

            builder.Property(p => p.ClienteId)
                .IsRequired();

            builder.Property(p => p.NumeroPedido)
                .IsRequired();

            builder.Property(p => p.DataEntrega);

            builder.Property(p => p.Descricao);

            builder.Property(p => p.Status);

            builder.HasMany(p => p.MateriasPrimas)
                .WithOne(p => p.Pedido)
                .HasForeignKey(p => p.PedidoId);

            builder.HasOne(p => p.Cliente)
                .WithMany(p => p.Pedidos)
                .HasForeignKey(p => p.ClienteId);
        }
    }
}

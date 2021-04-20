using DevIO.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevIO.Data.Data.Mappings
{
    public class PedidoMateriaPrimaEstoqueMapping : IEntityTypeConfiguration<PedidoMateriaPrimaEstoque>
    {
        public void Configure(EntityTypeBuilder<PedidoMateriaPrimaEstoque> builder)
        {
            builder.ToTable(nameof(PedidoMateriaPrimaEstoque));

            builder.Property(p => p.PedidoId)
                .IsRequired();

            builder.Property(p => p.MateriaPrimaEstoqueId)
                .IsRequired();

            builder.Property(p => p.Quantidade)
                .IsRequired();

            builder.HasOne(p => p.Pedido)
                .WithMany(p => p.MateriasPrimas)
                .HasForeignKey(p => p.PedidoId);

            builder.HasOne(p => p.MateriaPrimaEstoque)
                .WithMany(p => p.Pedidos)
                .HasForeignKey(p => p.MateriaPrimaEstoqueId);
        }
    }
}

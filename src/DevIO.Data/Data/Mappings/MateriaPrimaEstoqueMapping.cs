using DevIO.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevIO.Data.Data.Mappings
{
    public class MateriaPrimaEstoqueMapping : IEntityTypeConfiguration<MateriaPrimaEstoque>
    {
        public void Configure(EntityTypeBuilder<MateriaPrimaEstoque> builder)
        {
            builder.ToTable(nameof(MateriaPrimaEstoque));

            builder.Property(p => p.Nome)
                .IsRequired();

            builder.Property(p => p.Descricao)
                .IsRequired();

            builder.Property(p => p.Quantidade)
                .IsRequired();

            builder.HasMany(p => p.Compras)
                .WithOne(p => p.MateriaPrimaEstoque)
                .HasForeignKey(p => p.MateriaPrimaEstoqueId);

            builder.HasMany(p => p.Pedidos)
                .WithOne(p => p.MateriaPrimaEstoque)
                .HasForeignKey(p => p.MateriaPrimaEstoqueId);
        }
    }
}

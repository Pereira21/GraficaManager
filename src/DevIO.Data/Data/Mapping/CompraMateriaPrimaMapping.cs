using DevIO.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevIO.Data.Data.Mapping
{
    public class CompraMateriaPrimaMapping : IEntityTypeConfiguration<CompraMateriaPrima>
    {
        public void Configure(EntityTypeBuilder<CompraMateriaPrima> builder)
        {
            builder.ToTable(nameof(CompraMateriaPrima));

            builder.Property(p => p.MateriaPrimaEstoqueId)
                .IsRequired();

            builder.Property(p => p.UsuarioId)
                .IsRequired();

            builder.Property(p => p.Quantidade)
                .IsRequired();

            builder.Property(p => p.DataCompra)
                .IsRequired();

            builder.HasOne(p => p.MateriaPrimaEstoque)
                .WithMany(p => p.Compras)
                .HasForeignKey(p => p.MateriaPrimaEstoqueId);
        }
    }
}

using DevIO.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevIO.Data.Data.Mappings
{
    public class ClienteMapping : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable(nameof(Cliente));

            builder.Property(p => p.TipoPessoa)
                .IsRequired();

            builder.Property(p => p.CpfCnpj)
                .IsRequired();

            builder.Property(p => p.NomeCompleto);

            builder.Property(p => p.DataNascimento);

            builder.Property(p => p.RazaoSocial);

            builder.Property(p => p.NomeFantasia);

            builder.Property(p => p.TelefoneContato)
                .IsRequired();

            builder.Property(p => p.EmailContato)
                .IsRequired();

            builder.HasMany(p => p.Pedidos)
                .WithOne(c => c.Cliente)
                .HasForeignKey(p => p.ClienteId);
        }
    }
}

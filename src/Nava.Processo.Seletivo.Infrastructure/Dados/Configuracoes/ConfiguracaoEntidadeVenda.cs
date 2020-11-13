using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nava.Processo.Seletivo.Infraestrutura.Dados.Modelos;

namespace Nava.Processo.Seletivo.Infraestrutura.Dados.Configuracoes
{
    public sealed class ConfiguracaoEntidadeVenda : IEntityTypeConfiguration<Venda>
    {
        public void Configure(EntityTypeBuilder<Venda> builder)
        {
            builder.Property(p => p.Identificador).IsRequired();
            builder.Property(p => p.Data).IsRequired();
            builder.Property(p => p.IdentificadorPedido).IsRequired();
            builder.Property(p => p.CpfVendedor).IsRequired();
            builder.Property(p => p.Status).IsRequired();

            builder.HasOne<Vendedor>(p => p.Vendedor)
                .WithMany()
                .HasForeignKey(p => p.CpfVendedor)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne<Pedido>(p => p.Pedido)
                .WithMany()
                .HasForeignKey(p => p.IdentificadorPedido)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(i => i.Identificador);
            builder.HasIndex(i => new { i.IdentificadorPedido, i.CpfVendedor });

            builder.HasKey(k => k.Identificador);
        }
    }
}

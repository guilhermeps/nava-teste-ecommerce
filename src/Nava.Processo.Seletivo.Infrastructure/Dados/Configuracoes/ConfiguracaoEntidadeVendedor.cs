using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nava.Processo.Seletivo.Infraestrutura.Dados.Modelos;

namespace Nava.Processo.Seletivo.Infraestrutura.Dados.Configuracoes
{
    public sealed class ConfiguracaoEntidadeVendedor : IEntityTypeConfiguration<Vendedor>
    {
        public void Configure(EntityTypeBuilder<Vendedor> builder)
        {
            builder.Property(p => p.Cpf).IsRequired();
            builder.Property(p => p.Email).IsRequired();
            builder.Property(p => p.Nome).IsRequired();
            builder.Property(p => p.Telefone).IsRequired();

            builder.HasIndex(p => p.Cpf);

            builder.HasKey(k => k.Cpf);
        }
    }
}

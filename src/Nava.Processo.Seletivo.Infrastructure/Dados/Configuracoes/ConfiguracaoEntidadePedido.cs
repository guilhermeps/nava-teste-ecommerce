using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Nava.Processo.Seletivo.Infraestrutura.Dados.Modelos;
using System.Collections.Generic;

namespace Nava.Processo.Seletivo.Infraestrutura.Dados.Configuracoes
{
    public sealed class ConfiguracaoEntidadePedido : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(EntityTypeBuilder<Pedido> builder)
        {
            builder.Property(p => p.Identificador).IsRequired();

            // Obtido de https://stackoverflow.com/questions/37370476/how-to-persist-a-list-of-strings-with-entity-framework-core
            var tratamentoListaStrings = new ValueConverter<IList<string>, string>
                (v => string.Join(";", v), v => v.Split(new[] { ';' }));
            builder.Property(p => p.Itens).IsRequired().HasConversion(tratamentoListaStrings);

            builder.HasKey(k => k.Identificador);
        }
    }
}

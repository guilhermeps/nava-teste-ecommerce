using Microsoft.EntityFrameworkCore;
using Nava.Processo.Seletivo.Infraestrutura.Dados;
using Nava.Processo.Seletivo.Infraestrutura.Dados.Modelos;
using System;
using System.Threading.Tasks;

namespace Nava.Processo.Seletivo.Testes.Componentes
{
    internal class BaseDeDadosDeTeste
    {
        internal async Task<ContextoVendas> Preparar(Venda venda)
        {
            var opcoes = new DbContextOptionsBuilder<ContextoVendas>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            var contexto = new ContextoVendas(opcoes);
            await contexto.Database.EnsureCreatedAsync();
            contexto.Vendas.Add(venda);
            await contexto.SaveChangesAsync();

            return contexto;
        }
    }
}

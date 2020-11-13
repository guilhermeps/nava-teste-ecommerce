using Microsoft.EntityFrameworkCore;
using Nava.Processo.Seletivo.Infraestrutura.Dados.Configuracoes;
using Nava.Processo.Seletivo.Infraestrutura.Dados.Modelos;

namespace Nava.Processo.Seletivo.Infraestrutura.Dados
{
    public class ContextoVendas : DbContext
    {

        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Vendedor> Vendedores { get; set; }
        public DbSet<Venda> Vendas { get; set; }

        public ContextoVendas(DbContextOptions<ContextoVendas> options) 
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .ApplyConfigurationsFromAssembly(typeof(ConfiguracaoEntidadePedido).Assembly);
            modelBuilder
                .ApplyConfigurationsFromAssembly(typeof(ConfiguracaoEntidadeVendedor).Assembly);
            modelBuilder
                .ApplyConfigurationsFromAssembly(typeof(ConfiguracaoEntidadeVenda).Assembly);
        }
    }
}

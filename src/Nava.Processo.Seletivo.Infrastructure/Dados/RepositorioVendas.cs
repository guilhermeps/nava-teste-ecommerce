using Microsoft.EntityFrameworkCore;
using Nava.Processo.Seletivo.Dominio;
using Nava.Processo.Seletivo.Infraestrutura.Dados.Modelos.Mapeadores;
using Nava.Processo.Seletivo.Negocio.Repositorios;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Nava.Processo.Seletivo.Infraestrutura.Dados
{
    public sealed class RepositorioVendas : IRepositorioVenda
    {
        private readonly ContextoVendas contexto;

        public RepositorioVendas(ContextoVendas contexto)
            => this.contexto = contexto ?? throw new ArgumentNullException(nameof(contexto));

        public async Task Adicionar(Dominio.Venda venda)
        {
            var modeloVenda = MapeadorVenda.ParaModelo(venda);

            if (modeloVenda != null)
            {
                await contexto.Vendas.AddAsync(modeloVenda);
                await contexto.SaveChangesAsync();
            }
        }

        public async Task Atualizar(string identificadorVenda, StatusDaVenda status)
        {
            Modelos.Venda venda = contexto.Vendas
                .Where(v => v.Identificador == identificadorVenda)
                .FirstOrDefault();

            venda.Status = status;

            contexto.Entry(venda).State = EntityState.Modified;
            contexto.Vendas.Update(venda);
            await contexto.SaveChangesAsync();
        }

        public async Task<Dominio.Venda> Obter(string id)
        {
            Modelos.Venda modeloVenda = contexto.Vendas
                .Include(p => p.Pedido)
                .Include(v => v.Vendedor)
                .Where(v => v.Identificador== id).FirstOrDefault();
            Dominio.Venda vendaDominio = MapeadorVenda.ParaDominio(modeloVenda);

            return await Task.FromResult(vendaDominio);
        }
    }
}

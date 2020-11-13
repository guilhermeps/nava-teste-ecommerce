using Nava.Processo.Seletivo.Infraestrutura.Dados;
using Nava.Processo.Seletivo.Infraestrutura.Dados.Modelos;
using Nava.Processo.Seletivo.Negocio.CasosDeUso;
using Nava.Processo.Seletivo.Negocio.Fronteiras.AtualizarVenda;
using Nava.Processo.Seletivo.Negocio.Repositorios;
using Nava.Processo.Seletivo.WebApi.Controllers.AtualizarStatusVenda;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Nava.Processo.Seletivo.Testes.Componentes
{
    public class AtualizarStatusVenda
    {
        // Aqui estou testando apenas parte de um componente que engloba a integração
        // entre a classe de regra de negócio com a classe de repositório.
        [Theory]
        [ClassData(typeof(DadosDeVenda))]
        public async Task AtualizarStatus_DeveAtualizarStatusDeAguardandoPagamentoParaCancelada(Venda venda)
        {
            BaseDeDadosDeTeste baseDeDadosDeTeste = new BaseDeDadosDeTeste();
            ContextoVendas contexto = baseDeDadosDeTeste
                .Preparar(venda)
                .Result;
            IRepositorioVenda repositorio = new RepositorioVendas(contexto);
            IManipuladorDeSaida manipuladorDeSaida = new AtualizarStatusVendaApresentador();
            IAtualizarStatus atualizarStatus = new Negocio.CasosDeUso.AtualizarStatusVenda(repositorio, manipuladorDeSaida);

            await atualizarStatus.Atualizar(new Entrada(venda.Identificador, Dominio.StatusDaVenda.Cancelada));
            Venda vendaAtualizada = contexto.Vendas
                .Where(v => v.Identificador == venda.Identificador)
                .FirstOrDefault();

            Assert.Equal(Dominio.StatusDaVenda.Cancelada, vendaAtualizada.Status);
        }
    }
}

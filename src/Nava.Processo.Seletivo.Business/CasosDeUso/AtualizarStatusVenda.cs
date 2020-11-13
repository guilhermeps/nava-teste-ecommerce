using Nava.Processo.Seletivo.Dominio;
using Nava.Processo.Seletivo.Negocio.Fronteiras.AtualizarVenda;
using Nava.Processo.Seletivo.Negocio.Repositorios;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nava.Processo.Seletivo.Negocio.CasosDeUso
{
    public sealed class AtualizarStatusVenda : IAtualizarStatus
    {
        public const string MensagemTransicaoDeStatusInvalida = "Não é possível realizar essa transição de status";
        public const string MensagemParametrosInvalidos = "Parâmetros inválidos para atualização de status";
        private readonly IRepositorioVenda repositorio;
        private readonly IManipuladorDeSaida manipuladorDeSaida;
        private readonly IDictionary<StatusDaVenda, IList<StatusDaVenda>> transicoesDeStatus = 
            new Dictionary<StatusDaVenda, IList<StatusDaVenda>>();

        public AtualizarStatusVenda(
            IRepositorioVenda repositorio,
            IManipuladorDeSaida manipuladorDeSaida)
        {
            this.repositorio = repositorio;
            this.manipuladorDeSaida = manipuladorDeSaida;
            this.transicoesDeStatus
                .Add(StatusDaVenda.AguardandoPagamento, new List<StatusDaVenda> 
                {
                    StatusDaVenda.PagamentoAprovado, 
                    StatusDaVenda.Cancelada 
                });
            this.transicoesDeStatus
                .Add(StatusDaVenda.PagamentoAprovado, new List<StatusDaVenda> 
                { 
                    StatusDaVenda.EnviadoParaTransportadora, 
                    StatusDaVenda.Cancelada 
                });
            this.transicoesDeStatus
                .Add(StatusDaVenda.EnviadoParaTransportadora, new List<StatusDaVenda> 
                { 
                    StatusDaVenda.Entregue 
                });
        }

        public async Task Atualizar(Entrada entrada)
        {
            if (entrada.IsValid())
            {
                Venda venda = await repositorio.Obter(entrada.IdentificadorVenda);

                IList<KeyValuePair<StatusDaVenda, IList<StatusDaVenda>>> transicoesPossiveis = 
                    this.transicoesDeStatus.Where(s => s.Key == venda.Status).ToList();

                if (transicoesPossiveis.Any(s => s.Value.Contains(entrada.NovoStatus)))
                {
                    await repositorio
                    .Atualizar(entrada.IdentificadorVenda, entrada.NovoStatus);

                    manipuladorDeSaida.Construir(new Saida
                    {
                        IdentificadorVenda = entrada.IdentificadorVenda,
                        StatusVenda = entrada.NovoStatus
                    });
                }
                else
                {
                    manipuladorDeSaida.NotificarErro(MensagemTransicaoDeStatusInvalida);
                }

                return;
            }

            manipuladorDeSaida.NotificarErro(MensagemParametrosInvalidos);
        }
    }
}

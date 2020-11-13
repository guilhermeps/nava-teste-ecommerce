using Nava.Processo.Seletivo.Dominio;
using Nava.Processo.Seletivo.Negocio.Fronteiras.BuscarVenda;
using Nava.Processo.Seletivo.Negocio.Repositorios;
using System.Threading.Tasks;

namespace Nava.Processo.Seletivo.Negocio.CasosDeUso
{
    public sealed class BuscarVenda : IBuscarVenda
    {
        public const string MensagemErroBuscaVenda = "Não foi possível buscar a venda de id {0}.";
        private readonly IRepositorioVenda repositorio;
        private readonly IManipuladorDeSaida manipuladorDeSaida;

        public BuscarVenda(
            IRepositorioVenda repositorio, 
            IManipuladorDeSaida manipuladorDeSaida)
        {
            this.repositorio = repositorio;
            this.manipuladorDeSaida = manipuladorDeSaida;
        }

        public async Task Buscar(Entrada identificadorVenda)
        {
            if (identificadorVenda.IsValid())
            {
                Venda venda = await repositorio.Obter(identificadorVenda.IdVenda);

                manipuladorDeSaida.Construir(new Saida
                {
                    Data = venda.Data,
                    IdentificadorPedido = venda.Pedido.Identificador,
                    Itens = venda.Pedido.Itens,
                    NomeVendedor = venda.Vendedor.Nome
                });

                return;
            }

            manipuladorDeSaida
                .NotificarErro(string
                    .Format(MensagemErroBuscaVenda, identificadorVenda.IdVenda));
        }
    }
}

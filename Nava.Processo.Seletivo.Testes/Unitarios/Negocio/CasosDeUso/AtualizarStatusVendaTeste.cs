using Nava.Processo.Seletivo.Negocio.CasosDeUso;
using Nava.Processo.Seletivo.Negocio.Fronteiras.AtualizarVenda;
using Nava.Processo.Seletivo.Negocio.Repositorios;
using NSubstitute;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Nava.Processo.Seletivo.Testes.Unitarios.Negocio.CasosDeUso
{
    public class AtualizarStatusVendaTeste
    {
        private readonly IRepositorioVenda repositorio;
        private readonly IManipuladorDeSaida manipuladorDeSaida;

        public AtualizarStatusVendaTeste()
        {
            repositorio = Substitute.For<IRepositorioVenda>();
            manipuladorDeSaida = Substitute.For<IManipuladorDeSaida>();
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        [InlineData("  ")]
        public async Task Atualizar_DeveNotificarErro_QuandoNaoHouverIdDeVenda(string idVenda)
        {
            Entrada parametros = new Entrada(idVenda, Dominio.StatusDaVenda.AguardandoPagamento);
            IAtualizarStatus atualizarStatus = new AtualizarStatusVenda(repositorio, manipuladorDeSaida);

            await atualizarStatus.Atualizar(parametros);

            manipuladorDeSaida.Received(1).NotificarErro(AtualizarStatusVenda.MensagemParametrosInvalidos);
            await repositorio.DidNotReceiveWithAnyArgs().Atualizar(default, default);
        }

        [Fact]
        public async Task Atualizar_DeveNotificarErro_QuandoHouverTentativaDeTransicaoIndevidaEntreStatus()
        {
            string idVenda = "idVenda";
            repositorio.Obter(idVenda).Returns(Task.FromResult(new Dominio.Venda
            {
                Data = DateTime.Now,
                Identificador = idVenda,
                Status = Dominio.StatusDaVenda.AguardandoPagamento
            }));
            // Passando de Aguardando Pagamento para Entregue
            Entrada parametrosAtualizacao = new Entrada("idVenda", Dominio.StatusDaVenda.Entregue);
            IAtualizarStatus atualizarStatus = new AtualizarStatusVenda(repositorio, manipuladorDeSaida);

            await atualizarStatus.Atualizar(parametrosAtualizacao);

            manipuladorDeSaida.Received(1).NotificarErro(AtualizarStatusVenda.MensagemTransicaoDeStatusInvalida);
            await repositorio.DidNotReceiveWithAnyArgs().Atualizar(default, default);
        }
    }
}

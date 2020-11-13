using Microsoft.AspNetCore.Mvc;
using Nava.Processo.Seletivo.Negocio.Fronteiras.BuscarVenda;

namespace Nava.Processo.Seletivo.WebApi.Controllers.BuscarVenda
{
    public sealed class BuscarVendaApresentador : ResultadoDaAcao, IManipuladorDeSaida
    {
        public void Construir(Saida saida)
        {
            Resultado = new OkObjectResult(new
            {
                vendedor = saida.NomeVendedor,
                data_venda = saida.Data,
                identificador_pedido = saida.IdentificadorPedido,
                itens = saida.Itens
            });
        }

        public void NotificarErro(string mensagem)
        {
            Resultado = new BadRequestObjectResult(new
            {
                mensagem = mensagem
            });
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Nava.Processo.Seletivo.Negocio.Fronteiras.RegistrarVenda;

namespace Nava.Processo.Seletivo.WebApi.Controllers.RegistrarVenda
{
    public sealed class RegistrarVendaApresentador : ResultadoDaAcao, IManipuladorDeSaida
    {

        public void Construir(Saida saida)
        {
            Resultado = new CreatedResult($"/api/vendas/{saida.Identificador}", new
            {
                vendedor = saida.NomeVendedor,
                identificador_venda = saida.Identificador
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

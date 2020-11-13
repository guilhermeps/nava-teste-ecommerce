using EnumsNET;
using Microsoft.AspNetCore.Mvc;
using Nava.Processo.Seletivo.Negocio.Fronteiras.AtualizarVenda;

namespace Nava.Processo.Seletivo.WebApi.Controllers.AtualizarStatusVenda
{
    public sealed class AtualizarStatusVendaApresentador : ResultadoDaAcao, IManipuladorDeSaida
    {
        public void Construir(Saida saida)
        {
            Resultado = new OkObjectResult(new
            {
                identificador_venda = saida.IdentificadorVenda,
                status = saida.StatusVenda.AsString(EnumFormat.Description)
            });
        }

        public void NotificarErro(string mensagem)
        {
            Resultado = new BadRequestResult();
        }
    }
}

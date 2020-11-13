using Microsoft.AspNetCore.Mvc;
using Nava.Processo.Seletivo.Dominio;
using Nava.Processo.Seletivo.Negocio.Fronteiras.AtualizarVenda;
using Nava.Processo.Seletivo.WebApi.DTOs;
using System.Threading.Tasks;

namespace Nava.Processo.Seletivo.WebApi.Controllers.AtualizarStatusVenda
{
    [Route("api/vendas")]
    [ApiController]
    public class AtualizarStatusVendaController : Controller
    {
        private readonly AtualizarStatusVendaApresentador apresentador;

        public AtualizarStatusVendaController(AtualizarStatusVendaApresentador apresentador)
            => this.apresentador = apresentador;

        [HttpPatch("{idVenda}")]
        public async Task<IActionResult> Patch(
            [FromServices] IAtualizarStatus atualizarStatus,
            string idVenda, 
            [FromBody] VendaStatusDto vendaStatusDto)
        {
            StatusDaVenda novoStatus = EnumUtil
                .ObterEnumPelaDescricao<StatusDaVenda>(vendaStatusDto.NovoStatusVenda);
            
            await atualizarStatus.Atualizar(new Entrada(idVenda, novoStatus));

            return apresentador.Resultado;
        }
    }
}

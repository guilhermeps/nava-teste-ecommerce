using Microsoft.AspNetCore.Mvc;
using Nava.Processo.Seletivo.Negocio.Fronteiras.BuscarVenda;
using System.Threading.Tasks;

namespace Nava.Processo.Seletivo.WebApi.Controllers.BuscarVenda
{
    [Route("api/vendas")]
    [ApiController]
    public class BuscarVendaController : ControllerBase
    {
        private readonly BuscarVendaApresentador apresentador;

        public BuscarVendaController(BuscarVendaApresentador apresentador)
            => this.apresentador = apresentador;

        [HttpGet("{idVenda}")]
        public async Task<IActionResult> Get(
            [FromServices] IBuscarVenda buscarVenda, 
            string idVenda)
        {
            await buscarVenda.Buscar(new Entrada(idVenda));

            return apresentador.Resultado;
        }
    }
}

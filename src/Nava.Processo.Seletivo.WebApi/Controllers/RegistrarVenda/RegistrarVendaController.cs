using Microsoft.AspNetCore.Mvc;
using Nava.Processo.Seletivo.Negocio.Fronteiras.RegistrarVenda;
using Nava.Processo.Seletivo.WebApi.DTOs;
using System.Threading.Tasks;

namespace Nava.Processo.Seletivo.WebApi.Controllers.RegistrarVenda
{
    [Route("api/vendas")]
    [ApiController]
    public class RegistrarVendaController : ControllerBase
    {
        private readonly RegistrarVendaApresentador apresentador;

        public RegistrarVendaController(RegistrarVendaApresentador apresentador)
            => this.apresentador = apresentador;

        [HttpPost]
        public async Task<IActionResult> Post(
            [FromServices] IRegistrarVenda registrarVenda, 
            [FromBody] VendaDto venda)
        {
            await registrarVenda.Registrar(new Entrada
            {
                Cpf = venda.Cpf,
                Email = venda.Email,
                Nome = venda.Nome,
                ItensVendidos = venda.ItensVendidos,
                Telefone = venda.Telefone
            });

            return apresentador.Resultado;
        }
    }
}

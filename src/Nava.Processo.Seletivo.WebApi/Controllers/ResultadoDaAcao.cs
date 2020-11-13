using Microsoft.AspNetCore.Mvc;

namespace Nava.Processo.Seletivo.WebApi.Controllers
{
    public abstract class ResultadoDaAcao
    {
        public IActionResult Resultado { get; protected set; }
    }
}

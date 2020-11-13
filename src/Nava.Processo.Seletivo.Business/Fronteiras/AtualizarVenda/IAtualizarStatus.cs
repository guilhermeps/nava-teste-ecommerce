using Nava.Processo.Seletivo.Dominio;
using System.Threading.Tasks;

namespace Nava.Processo.Seletivo.Negocio.Fronteiras.AtualizarVenda
{
    public interface IAtualizarStatus
    {
        Task Atualizar(Entrada entrada);
    }
}

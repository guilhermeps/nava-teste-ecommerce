using System.Threading.Tasks;

namespace Nava.Processo.Seletivo.Negocio.Fronteiras.BuscarVenda
{
    public interface IBuscarVenda
    {
        Task Buscar(Entrada identificadorVenda);
    }
}

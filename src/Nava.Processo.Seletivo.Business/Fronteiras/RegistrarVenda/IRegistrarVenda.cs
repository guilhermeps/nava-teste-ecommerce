using System.Threading.Tasks;

namespace Nava.Processo.Seletivo.Negocio.Fronteiras.RegistrarVenda
{
    public interface IRegistrarVenda
    {
        Task Registrar(Entrada entrada);
    }
}

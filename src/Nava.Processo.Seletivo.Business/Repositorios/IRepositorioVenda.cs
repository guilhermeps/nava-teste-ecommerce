using Nava.Processo.Seletivo.Dominio;
using System.Threading.Tasks;

namespace Nava.Processo.Seletivo.Negocio.Repositorios
{
    public interface IRepositorioVenda
    {
        Task Adicionar(Venda venda);

        Task<Venda> Obter(string id);

        Task Atualizar(string identificadorVenda, StatusDaVenda status);
    }
}

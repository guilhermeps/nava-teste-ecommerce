using Nava.Processo.Seletivo.Testes.ConfiguracaoTestes;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace Nava.Processo.Seletivo.Testes.Integração
{
    public class BuscarVendaTeste : ConfiguracaoBase
    {
        [Fact]
        public async Task Buscar_DeveBuscarUmaVenda()
        {
            string urlBusca = await CriarVenda();

            var resposta = await ClienteHttp.GetAsync(urlBusca);

            Assert.Equal(HttpStatusCode.OK, resposta.StatusCode);
        }
    }
}

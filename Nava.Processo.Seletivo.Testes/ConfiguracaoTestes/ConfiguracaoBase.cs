using Microsoft.AspNetCore.Mvc.Testing;
using Nava.Processo.Seletivo.WebApi;
using Nava.Processo.Seletivo.WebApi.DTOs;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Nava.Processo.Seletivo.Testes.ConfiguracaoTestes
{
    public class ConfiguracaoBase
    {
        protected readonly HttpClient ClienteHttp;

        protected ConfiguracaoBase()
        {
            var appFactory = new WebApplicationFactory<Startup>();
            ClienteHttp = appFactory.CreateClient();
        }

        protected async Task<string> CriarVenda()
        {
            VendaDto venda = new VendaDto
            {
                Cpf = "00000000000",
                Email = "teste@email.com",
                Nome = "Fulano",
                Telefone = "5531000000000",
                ItensVendidos = new List<string>() { "Geladeira" }
            };
            
            ByteArrayContent conteudo = CriarPayload(venda);

            var resposta = await ClienteHttp.PostAsync("/api/vendas", conteudo);

            return resposta.Headers.Location.OriginalString;
        }

        protected ByteArrayContent CriarPayload(VendaDto venda)
        {
            var vendaComoJson = JsonConvert.SerializeObject(venda);
            var buffer = Encoding.UTF8.GetBytes(vendaComoJson);
            var conteudo = new ByteArrayContent(buffer);
            conteudo.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            return conteudo;
        }
    }
}

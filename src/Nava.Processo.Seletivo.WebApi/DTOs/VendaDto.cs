using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Nava.Processo.Seletivo.WebApi.DTOs
{
    public class VendaDto
    {
        [JsonProperty("cpf")]
        public string Cpf { get; set; }

        [JsonProperty("nome")]
        public string Nome { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("telefone")]
        public string Telefone { get; set; }

        [JsonProperty("itens")]
        [JsonPropertyName("itens")]
        public IList<string> ItensVendidos { get; set; }
    }
}

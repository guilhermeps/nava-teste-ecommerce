using System.Text.Json.Serialization;

namespace Nava.Processo.Seletivo.WebApi.DTOs
{
    public class VendaStatusDto
    {
        [JsonPropertyName("status")]
        public string NovoStatusVenda { get; set; }
    }
}

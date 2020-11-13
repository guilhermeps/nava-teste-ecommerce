using Nava.Processo.Seletivo.Dominio;

namespace Nava.Processo.Seletivo.Negocio.Fronteiras.AtualizarVenda
{
    public sealed class Entrada
    {
        public string IdentificadorVenda { get; set; }

        public StatusDaVenda NovoStatus { get; set; }

        public Entrada(string identificadorVenda, StatusDaVenda novoStatus)
        {
            this.IdentificadorVenda = identificadorVenda;
            this.NovoStatus = novoStatus;
        }

        public bool IsValid() => !string.IsNullOrWhiteSpace(this.IdentificadorVenda);
    }
}

using Nava.Processo.Seletivo.Dominio;

namespace Nava.Processo.Seletivo.Negocio.Fronteiras.AtualizarVenda
{
    public sealed class Saida
    {
        public string IdentificadorVenda { get; set; }

        public StatusDaVenda StatusVenda { get; set; }
    }
}

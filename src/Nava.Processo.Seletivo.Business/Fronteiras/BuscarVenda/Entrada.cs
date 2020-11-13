namespace Nava.Processo.Seletivo.Negocio.Fronteiras.BuscarVenda
{
    public class Entrada
    {
        public string IdVenda { get; private set; }

        public Entrada(string id) => this.IdVenda = id;

        public bool IsValid() => !string.IsNullOrWhiteSpace(this.IdVenda);
    }
}

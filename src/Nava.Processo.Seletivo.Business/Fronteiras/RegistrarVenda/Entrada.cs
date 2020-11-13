using System.Collections.Generic;

namespace Nava.Processo.Seletivo.Negocio.Fronteiras.RegistrarVenda
{
    public sealed class Entrada
    {
        public string Cpf { get; set; }

        public string Nome { get; set; }

        public string Email { get; set; }

        public string Telefone { get; set; }

        public IList<string> ItensVendidos { get; set; }

        public bool IsValid()
        {
            if (string.IsNullOrWhiteSpace(Cpf))
                return false;

            if (string.IsNullOrWhiteSpace(Nome))
                return false;

            if (string.IsNullOrWhiteSpace(Email))
                return false;

            if (string.IsNullOrWhiteSpace(Telefone))
                return false;

            if (ItensVendidos.Count == 0)
                return false;

            return true;
        }
    }
}

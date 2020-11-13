using System.Collections.Generic;

namespace Nava.Processo.Seletivo.Dominio
{
    public sealed class Pedido
    {
        public string Identificador { get; set; }

        public IList<string> Itens { get; set; }
    }
}

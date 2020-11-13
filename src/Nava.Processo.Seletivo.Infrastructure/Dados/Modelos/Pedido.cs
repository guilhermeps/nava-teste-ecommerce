using System.Collections.Generic;

namespace Nava.Processo.Seletivo.Infraestrutura.Dados.Modelos
{
    public class Pedido
    {
        public string Identificador { get; set; }

        public IList<string> Itens { get; set; }
    }
}

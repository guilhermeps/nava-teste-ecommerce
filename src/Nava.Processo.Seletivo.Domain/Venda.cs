using System;

namespace Nava.Processo.Seletivo.Dominio
{
    public sealed class Venda
    {
        public string Identificador { get; set; }

        public DateTime Data { get; set; }

        public Pedido Pedido { get; set; }

        public StatusDaVenda Status { get; set; }

        public Vendedor Vendedor { get; set; }
    }
}

using Nava.Processo.Seletivo.Dominio;
using System;

namespace Nava.Processo.Seletivo.Infraestrutura.Dados.Modelos
{
    public class Venda
    {
        public string IdentificadorPedido { get; set; }

        public string CpfVendedor { get; set; }

        public string Identificador { get; set; }

        public DateTime Data { get; set; }

        public Pedido Pedido { get; set; }

        public StatusDaVenda Status { get; set; }

        public Vendedor Vendedor { get; set; }
    }
}

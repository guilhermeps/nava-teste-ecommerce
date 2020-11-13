using Nava.Processo.Seletivo.Dominio;
using System;
using System.Collections.Generic;

namespace Nava.Processo.Seletivo.Negocio.Fronteiras.BuscarVenda
{
    public class Saida
    {
        public DateTime Data { get; set; }

        public string IdentificadorPedido { get; set; }

        public string NomeVendedor { get; set; }

        public IList<string> Itens { get; set; }
    }
}

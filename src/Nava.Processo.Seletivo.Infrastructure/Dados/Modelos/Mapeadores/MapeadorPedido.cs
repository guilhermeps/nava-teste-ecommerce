using System.Collections.Generic;

namespace Nava.Processo.Seletivo.Infraestrutura.Dados.Modelos.Mapeadores
{
    public static class MapeadorPedido
    {
        public static Pedido ParaModelo(Dominio.Pedido pedido)
        {
            if (pedido != null)
            {
                return new Pedido
                {
                    Identificador = pedido.Identificador,
                    Itens = pedido.Itens
                };
            }

            return null;
        }

        public static Dominio.Pedido ParaDominio(Pedido pedido)
        {
            return new Dominio.Pedido
            {
                Identificador = pedido.Identificador,
                Itens = pedido.Itens
            };
        }
    }
}

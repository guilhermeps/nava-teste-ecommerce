namespace Nava.Processo.Seletivo.Infraestrutura.Dados.Modelos.Mapeadores
{
    public static class MapeadorVenda
    {
        public static Venda ParaModelo(Dominio.Venda venda)
        {
            if (venda != null) 
            {
                return new Venda
                {
                    Data = venda.Data,
                    Identificador = venda.Identificador,
                    Status = venda.Status,
                    CpfVendedor = venda.Vendedor.Cpf,
                    IdentificadorPedido = venda.Pedido.Identificador,
                    Pedido = MapeadorPedido.ParaModelo(venda.Pedido),
                    Vendedor = MapeadorVendedor.ParaModelo(venda.Vendedor)
                };
            }

            return null;
        }

        public static Dominio.Venda ParaDominio(Venda venda)
        {
            return new Dominio.Venda
            {
                Data = venda.Data,
                Identificador = venda.Identificador,
                Pedido = MapeadorPedido.ParaDominio(venda.Pedido),
                Status = venda.Status,
                Vendedor = MapeadorVendedor.ParaDominio(venda.Vendedor)
            };
        }
    }
}

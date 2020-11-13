using Nava.Processo.Seletivo.Infraestrutura.Dados.Modelos;
using System;
using System.Collections.Generic;
using Xunit;

namespace Nava.Processo.Seletivo.Testes.Componentes
{
    internal class DadosDeVenda : TheoryData<Venda>
    {
        public DadosDeVenda()
        {
            DateTime dataDaVenda = DateTime.Now;
            string idPedido = Guid.NewGuid().ToString();
            IList<string> itens = new List<string> { "item 1", "item 2" };
            string nomeVendedor = "Fulano";

            Add(new Infraestrutura.Dados.Modelos.Venda
            {
                CpfVendedor = "00000000000",
                Data = dataDaVenda,
                Identificador = Guid.NewGuid().ToString(),
                IdentificadorPedido = "idPedido",
                Pedido = new Infraestrutura.Dados.Modelos.Pedido
                {
                    Identificador = idPedido,
                    Itens = itens
                },
                Status = Dominio.StatusDaVenda.AguardandoPagamento,
                Vendedor = new Infraestrutura.Dados.Modelos.Vendedor
                {
                    Cpf = "11111111111",
                    Email = "email@teste.com",
                    Nome = nomeVendedor,
                    Telefone = "99999999999"
                }
            });
        }
    }
}

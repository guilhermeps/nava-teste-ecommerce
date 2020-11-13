using Nava.Processo.Seletivo.Dominio;
using Nava.Processo.Seletivo.Negocio.Fronteiras.RegistrarVenda;
using Nava.Processo.Seletivo.Negocio.Repositorios;
using System;
using System.Threading.Tasks;

namespace Nava.Processo.Seletivo.Negocio.CasosDeUso
{
    public sealed class RegistrarVenda : IRegistrarVenda
    {
        public const string Erro_Registro_Venda = "Não foi possível registrar a venda.";

        private readonly IRepositorioVenda repositorio;
        private readonly IManipuladorDeSaida manipuladorDeSaida;

        public RegistrarVenda(
            IRepositorioVenda repositorio, 
            IManipuladorDeSaida manipuladorDeSaida)
        {
            this.repositorio = repositorio;
            this.manipuladorDeSaida = manipuladorDeSaida;
        }

        public async Task Registrar(Entrada entrada)
        {
            if (entrada.IsValid())
            {
                Venda vendaGerada = new Venda
                {
                    Identificador = Guid.NewGuid().ToString(),
                    Data = DateTime.Now,
                    Pedido = new Pedido
                    {
                        Identificador = Guid.NewGuid().ToString(),
                        Itens = entrada.ItensVendidos
                    },
                    Status = StatusDaVenda.AguardandoPagamento,
                    Vendedor = new Vendedor
                    {
                        Cpf = entrada.Cpf,
                        Email = entrada.Email,
                        Nome = entrada.Nome,
                        Telefone = entrada.Telefone
                    }
                };

                await repositorio.Adicionar(vendaGerada);

                manipuladorDeSaida.Construir(new Saida
                {
                    NomeVendedor = vendaGerada.Vendedor.Nome,
                    Identificador = vendaGerada.Identificador,
                });
                
                return;
            }

            manipuladorDeSaida.NotificarErro(Erro_Registro_Venda);
        }
    }
}

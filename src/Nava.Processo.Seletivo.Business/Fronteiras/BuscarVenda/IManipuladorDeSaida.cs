namespace Nava.Processo.Seletivo.Negocio.Fronteiras.BuscarVenda
{
    public interface IManipuladorDeSaida : IManipuladorDeErro
    {
        void Construir(Saida saida);
    }
}

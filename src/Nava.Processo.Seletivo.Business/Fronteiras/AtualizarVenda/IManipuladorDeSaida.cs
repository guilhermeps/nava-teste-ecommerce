namespace Nava.Processo.Seletivo.Negocio.Fronteiras.AtualizarVenda
{
    public interface IManipuladorDeSaida : IManipuladorDeErro
    {
        void Construir(Saida saida);
    }
}

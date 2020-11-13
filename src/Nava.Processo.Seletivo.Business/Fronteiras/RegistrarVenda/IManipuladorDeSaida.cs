namespace Nava.Processo.Seletivo.Negocio.Fronteiras.RegistrarVenda
{
    public interface IManipuladorDeSaida : IManipuladorDeErro
    {
        void Construir(Saida saida);
    }
}

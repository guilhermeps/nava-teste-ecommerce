namespace Nava.Processo.Seletivo.Infraestrutura.Dados.Modelos.Mapeadores
{
    public static class MapeadorVendedor
    {
        public static Vendedor ParaModelo(Dominio.Vendedor vendedor)
        {
            if (vendedor != null)
            {
                return new Vendedor
                {
                    Cpf = vendedor.Cpf,
                    Email = vendedor.Email,
                    Nome = vendedor.Nome,
                    Telefone = vendedor.Telefone
                };
            }

            return null;
        }

        public static Dominio.Vendedor ParaDominio(Vendedor vendedor)
        {
            return new Dominio.Vendedor
            {
                Cpf = vendedor.Cpf,
                Email = vendedor.Email,
                Nome = vendedor.Nome,
                Telefone = vendedor.Telefone
            };
        }
    }
}

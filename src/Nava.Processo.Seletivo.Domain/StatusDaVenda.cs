using System.ComponentModel;

namespace Nava.Processo.Seletivo.Dominio
{
    public enum StatusDaVenda
    {
        [Description("AGUARDANDO PAGAMENTO")]
        AguardandoPagamento,

        [Description("PAGAMENTO APROVADO")]
        PagamentoAprovado,

        [Description("ENVIADO PARA TRANSPORTADORA")]
        EnviadoParaTransportadora,

        [Description("ENTREGUE")]
        Entregue,

        [Description("CANCELADA")]
        Cancelada
    }
}

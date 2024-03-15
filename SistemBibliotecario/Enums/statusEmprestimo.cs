using System.ComponentModel;

namespace LojinhaVendas.Enums
{
    public enum statusEmprestimo
    {
        [Description("Disponivel")]
        Disponivel = 1,
        [Description("Aguardando Retirada")]
        Aguardando = 2,
        [Description("Emrpestado")]
        Emrpestado = 3,

    }
}

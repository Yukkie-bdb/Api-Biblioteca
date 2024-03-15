using System.ComponentModel;

namespace LojinhaVendas.Enums
{
    public enum statusReserva
    {
        [Description("Disponivel")]
        Disponivel = 1,
        [Description("Reservado")]
        Aguardando = 2,
    }
}

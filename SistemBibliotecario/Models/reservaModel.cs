using LojinhaVendas.Enums;

namespace SistemBibliotecario.Models;

public class reservaModel
{
    public int Id { get; set; }
    public DateOnly dataReserva { get; set; }
    
    public statusReserva status { get; set; }

    public virtual livroModel? livro { get; set; }
    public int livroId { get; set; }
    
    public virtual usuarioModel? usuario { get; set; }
    public int usuarioId { get; set; }
}
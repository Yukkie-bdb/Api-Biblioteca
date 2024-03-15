using LojinhaVendas.Enums;

namespace SistemBibliotecario.Models;

public class emprestimoModel
{
    public int Id { get; set; }
    public DateOnly dataEmprestimo { get; set; }
    public DateOnly dataDevolucao { get; set; }
    
    public statusEmprestimo status { get; set; }
    
    public virtual livroModel? livro { get; set; }
    public int livroId { get; set; }
    
    public virtual usuarioModel? usuario { get; set; }
    public int usuarioId { get; set; }
}
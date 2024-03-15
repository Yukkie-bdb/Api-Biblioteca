namespace SistemBibliotecario.Models;

public class avaliacaoModel
{
    public int Id { get; set; }
    public int pontuacao { get; set; }
    public string comentario { get; set; }
    public DateOnly dataAvaliacao { get; set; }
    
    public virtual livroModel? livro { get; set; }
    public int livroId { get; set; }
    
    public virtual usuarioModel? usuario { get; set; }
    public int usuarioId { get; set; }
}
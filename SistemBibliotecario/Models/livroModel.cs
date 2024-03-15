namespace SistemBibliotecario.Models;

public class livroModel
{
    public int Id { get; set; }
    public string titulo { get; set; }
    public string genero { get; set; }
    public int anoPublicacao { get; set; }
    public int ISBN { get; set; }
    public string sinopse { get; set; }

}
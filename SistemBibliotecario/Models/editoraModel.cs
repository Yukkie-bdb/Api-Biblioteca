namespace SistemBibliotecario.Models;

public class editoraModel
{
    public int Id { get; set; }
    public string nome { get; set; }
    public string localizacao { get; set; }
    public int anoFundacao { get; set; }
    public ICollection<livroModel>? livros { get; set; }

}
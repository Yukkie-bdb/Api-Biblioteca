using SistemBibliotecario.Models;

namespace SistemBibliotecario.Repositorio.Interfaces;

public interface IEditoraRepositorio
{
    Task<List<editoraModel>> BuscarTodos();
    
    Task<editoraModel> BuscarPorId(int id);

    Task<editoraModel> Adicionar(editoraModel editora);

    Task<editoraModel> Atualizar(editoraModel editora, int id);

    Task<bool> Apagar(int id);
}
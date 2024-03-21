using SistemBibliotecario.Models;

namespace SistemBibliotecario.Repositorio.Interfaces;

public interface IEmprestimoRepositorio
{
    Task<List<emprestimoModel>> BuscarTodos();
    
    Task<emprestimoModel> BuscarPorId(int id);

    Task<emprestimoModel> Adicionar(emprestimoModel autor);

    Task<emprestimoModel> Atualizar(emprestimoModel autor, int id);

    Task<bool> Apagar(int id);
}
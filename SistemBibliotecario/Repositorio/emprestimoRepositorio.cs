using Microsoft.EntityFrameworkCore;
using SistemBibliotecario.Data;
using SistemBibliotecario.Repositorio.Interfaces;
using SistemBibliotecario.Models;

namespace SistemBibliotecario.Repositorio;

public class EmprestimoRepositorio : IEmprestimoRepositorio
{
    private readonly bibliotecaDBContext _dbContext;

    public EmprestimoRepositorio(bibliotecaDBContext bibliotecaDbContext)
    {
        _dbContext = bibliotecaDbContext;
    }

    public async Task<emprestimoModel> BuscarPorId(int id)
    {
        return await _dbContext.Emprestimos.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<List<emprestimoModel>> BuscarTodos()
    {
        return await _dbContext.Emprestimos.ToListAsync();
    }
    public async Task<emprestimoModel> Adicionar(emprestimoModel autor)
    {
        await _dbContext.Emprestimos.AddAsync(autor);
        await _dbContext.SaveChangesAsync();

        return autor;
    }

    public async Task<bool> Apagar(int id)
    {
        emprestimoModel autorPorId = await BuscarPorId(id);


        if (autorPorId == null)
        {
            throw new Exception($"Usuário do ID: {id} não foi encontrado");
        }

        _dbContext.Emprestimos.Remove(autorPorId);
        await _dbContext.SaveChangesAsync();

        return true;
           
    }

    public async Task<emprestimoModel> Atualizar(emprestimoModel autor, int id)
    {
        emprestimoModel autorPorId = await BuscarPorId(id);


        if (autorPorId == null)
        {
            throw new Exception($"Usuário do ID: {id} não foi encontrado");
        }

        autorPorId.dataEmprestimo = autor.dataEmprestimo;
        autorPorId.dataDevolucao = autor.dataDevolucao;
        autorPorId.status = autor.status;
        autorPorId.livroId = autor.livroId;
        autorPorId.usuarioId = autor.usuarioId;
   

        _dbContext.Emprestimos.Update(autorPorId);
        await _dbContext.SaveChangesAsync();

        return autorPorId;
    }

   
}


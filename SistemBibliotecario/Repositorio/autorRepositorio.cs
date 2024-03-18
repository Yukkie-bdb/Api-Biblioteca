using Microsoft.EntityFrameworkCore;
using SistemBibliotecario.Data;
using SistemBibliotecario.Repositorio.Interfaces;
using SistemBibliotecario.Models;

namespace SistemBibliotecario.Repositorio;

public class AutorRepositorio : IAutorRepositorio
{
    private readonly bibliotecaDBContext _dbContext;

    public AutorRepositorio(bibliotecaDBContext bibliotecaDbContext)
    {
        _dbContext = bibliotecaDbContext;
    }

    public async Task<autorModel> BuscarPorId(int id)
    {
        return await _dbContext.Autores.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<List<autorModel>> BuscarTodos()
    {
        return await _dbContext.Autores.ToListAsync();
    }
    public async Task<autorModel> Adicionar(autorModel autor)
    {
        await _dbContext.Autores.AddAsync(autor);
        await _dbContext.SaveChangesAsync();

        return autor;
    }

    public async Task<bool> Apagar(int id)
    {
        autorModel autorPorId = await BuscarPorId(id);


        if (autorPorId == null)
        {
            throw new Exception($"Usuário do ID: {id} não foi encontrado");
        }

        _dbContext.Autores.Remove(autorPorId);
        await _dbContext.SaveChangesAsync();

        return true;
           
    }

    public async Task<autorModel> Atualizar(autorModel autor, int id)
    {
        autorModel autorPorId = await BuscarPorId(id);


        if (autorPorId == null)
        {
            throw new Exception($"Usuário do ID: {id} não foi encontrado");
        }

        autorPorId.nome = autor.nome;
        autorPorId.nacionalidade = autor.nacionalidade;
        autorPorId.dataNascimento = autor.dataNascimento;
   

        _dbContext.Autores.Update(autorPorId);
        await _dbContext.SaveChangesAsync();

        return autorPorId;
    }

   
}


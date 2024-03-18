using Microsoft.EntityFrameworkCore;
using SistemBibliotecario.Data;
using SistemBibliotecario.Repositorio.Interfaces;
using SistemBibliotecario.Models;

namespace SistemBibliotecario.Repositorio;

public class LivroRepositorio : ILivroRepositorio
{
    private readonly bibliotecaDBContext _dbContext;

    public LivroRepositorio(bibliotecaDBContext bibliotecaDbContext)
    {
        _dbContext = bibliotecaDbContext;
    }

    public async Task<livroModel> BuscarPorId(int id)
    {
        return await _dbContext.Livros.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<List<livroModel>> BuscarTodos()
    {
        return await _dbContext.Livros.ToListAsync();
    }
    public async Task<livroModel> Adicionar(livroModel usuario)
    {
        await _dbContext.Livros.AddAsync(usuario);
        await _dbContext.SaveChangesAsync();

        return usuario;
    }

    public async Task<bool> Apagar(int id)
    {
        livroModel livroPorId = await BuscarPorId(id);


        if (livroPorId == null)
        {
            throw new Exception($"Usuário do ID: {id} não foi encontrado");
        }

        _dbContext.Livros.Remove(livroPorId);
        await _dbContext.SaveChangesAsync();

        return true;
           
    }

    public async Task<livroModel> Atualizar(livroModel usuario, int id)
    {
        livroModel livroPorId = await BuscarPorId(id);


        if (livroPorId == null)
        {
            throw new Exception($"Usuário do ID: {id} não foi encontrado");
        }

        livroPorId.titulo = usuario.titulo;
        livroPorId.genero = usuario.genero;
        livroPorId.anoPublicacao = usuario.anoPublicacao;
        livroPorId.ISBN = usuario.ISBN;
        livroPorId.sinopse = usuario.sinopse;

        _dbContext.Livros.Update(livroPorId);
        await _dbContext.SaveChangesAsync();

        return livroPorId;
    }

   
}


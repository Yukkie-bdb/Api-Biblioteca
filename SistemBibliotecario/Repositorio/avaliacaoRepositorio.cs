using Microsoft.EntityFrameworkCore;
using SistemBibliotecario.Data;
using SistemBibliotecario.Repositorio.Interfaces;
using SistemBibliotecario.Models;

namespace SistemBibliotecario.Repositorio;

public class AvaliacaoRepositorio : IAvaliacaoRepositorio
{
    private readonly bibliotecaDBContext _dbContext;

    public AvaliacaoRepositorio(bibliotecaDBContext bibliotecaDbContext)
    {
        _dbContext = bibliotecaDbContext;
    }

    public async Task<avaliacaoModel> BuscarPorId(int id)
    {
        return await _dbContext.Avaliacoes.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<List<avaliacaoModel>> BuscarTodos()
    {
        return await _dbContext.Avaliacoes.ToListAsync();
    }
    public async Task<avaliacaoModel> Adicionar(avaliacaoModel autor)
    {
        await _dbContext.Avaliacoes.AddAsync(autor);
        await _dbContext.SaveChangesAsync();

        return autor;
    }

    public async Task<bool> Apagar(int id)
    {
        avaliacaoModel autorPorId = await BuscarPorId(id);


        if (autorPorId == null)
        {
            throw new Exception($"Usuário do ID: {id} não foi encontrado");
        }

        _dbContext.Avaliacoes.Remove(autorPorId);
        await _dbContext.SaveChangesAsync();

        return true;
           
    }

    public async Task<avaliacaoModel> Atualizar(avaliacaoModel autor, int id)
    {
        avaliacaoModel autorPorId = await BuscarPorId(id);


        if (autorPorId == null)
        {
            throw new Exception($"Usuário do ID: {id} não foi encontrado");
        }

        autorPorId.pontuacao = autor.pontuacao;
        autorPorId.comentario = autor.comentario;
        autorPorId.dataAvaliacao = autor.dataAvaliacao;
        autorPorId.livroId = autor.livroId;
        autorPorId.usuarioId = autor.usuarioId;
   

        _dbContext.Avaliacoes.Update(autorPorId);
        await _dbContext.SaveChangesAsync();

        return autorPorId;
    }

   
}


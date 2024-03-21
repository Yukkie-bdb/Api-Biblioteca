using Microsoft.EntityFrameworkCore;
using SistemBibliotecario.Data;
using SistemBibliotecario.Repositorio.Interfaces;
using SistemBibliotecario.Models;

namespace SistemBibliotecario.Repositorio;

public class ReservaRepositorio : IReservaRepositorio
{
    private readonly bibliotecaDBContext _dbContext;

    public ReservaRepositorio(bibliotecaDBContext bibliotecaDbContext)
    {
        _dbContext = bibliotecaDbContext;
    }

    public async Task<reservaModel> BuscarPorId(int id)
    {
        return await _dbContext.Reservas.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<List<reservaModel>> BuscarTodos()
    {
        return await _dbContext.Reservas.ToListAsync();
    }
    public async Task<reservaModel> Adicionar(reservaModel autor)
    {
        await _dbContext.Reservas.AddAsync(autor);
        await _dbContext.SaveChangesAsync();

        return autor;
    }

    public async Task<bool> Apagar(int id)
    {
        reservaModel autorPorId = await BuscarPorId(id);


        if (autorPorId == null)
        {
            throw new Exception($"Usuário do ID: {id} não foi encontrado");
        }

        _dbContext.Reservas.Remove(autorPorId);
        await _dbContext.SaveChangesAsync();

        return true;
           
    }

    public async Task<reservaModel> Atualizar(reservaModel autor, int id)
    {
        reservaModel autorPorId = await BuscarPorId(id);


        if (autorPorId == null)
        {
            throw new Exception($"Usuário do ID: {id} não foi encontrado");
        }

        autorPorId.dataReserva = autor.dataReserva;
        autorPorId.status = autor.status;
        autorPorId.livroId = autor.livroId;
        autorPorId.usuarioId = autor.usuarioId;
   

        _dbContext.Reservas.Update(autorPorId);
        await _dbContext.SaveChangesAsync();

        return autorPorId;
    }

   
}


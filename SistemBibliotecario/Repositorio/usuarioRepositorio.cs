using Microsoft.EntityFrameworkCore;
using SistemBibliotecario.Data;
using SistemBibliotecario.Repositorio.Interfaces;
using SistemBibliotecario.Models;

namespace SistemBibliotecario.Repositorio;

public class UsuarioRepositorio : IUsuarioRepositorio
{
    private readonly bibliotecaDBContext _dbContext;

    public UsuarioRepositorio(bibliotecaDBContext bibliotecaDbContext)
    {
        _dbContext = bibliotecaDbContext;
    }

    public async Task<usuarioModel> BuscarPorId(int id)
    {
        return await _dbContext.Usuarios.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<List<usuarioModel>> BuscarTodos()
    {
        return await _dbContext.Usuarios.ToListAsync();
    }
    public async Task<usuarioModel> Adicionar(usuarioModel usuario)
    {
        await _dbContext.Usuarios.AddAsync(usuario);
        await _dbContext.SaveChangesAsync();

        return usuario;
    }

    public async Task<bool> Apagar(int id)
    {
        usuarioModel usuarioPorId = await BuscarPorId(id);


        if (usuarioPorId == null)
        {
            throw new Exception($"Usuário do ID: {id} não foi encontrado");
        }

        _dbContext.Usuarios.Remove(usuarioPorId);
        await _dbContext.SaveChangesAsync();

        return true;
           
    }

    public async Task<usuarioModel> Atualizar(usuarioModel usuario, int id)
    {
        usuarioModel usuarioPorId = await BuscarPorId(id);


        if (usuarioPorId == null)
        {
            throw new Exception($"Usuário do ID: {id} não foi encontrado");
        }

        usuarioPorId.senha = usuario.senha;
        usuarioPorId.email = usuario.email;

        _dbContext.Usuarios.Update(usuarioPorId);
        await _dbContext.SaveChangesAsync();

        return usuarioPorId;
    }

   
}


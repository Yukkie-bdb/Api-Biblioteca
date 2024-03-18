using Microsoft.EntityFrameworkCore;
using SistemBibliotecario.Data;
using SistemBibliotecario.Repositorio.Interfaces;
using SistemBibliotecario.Models;

namespace SistemBibliotecario.Repositorio;

public class EditorarRepositorio : IEditoraRepositorio
{
    private readonly bibliotecaDBContext _dbContext;

    public EditorarRepositorio(bibliotecaDBContext bibliotecaDbContext)
    {
        _dbContext = bibliotecaDbContext;
    }

    public async Task<editoraModel> BuscarPorId(int id)
    {
        return await _dbContext.Editores.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<List<editoraModel>> BuscarTodos()
    {
        return await _dbContext.Editores.ToListAsync();
    }
    public async Task<editoraModel> Adicionar(editoraModel editora)
    {
        await _dbContext.Editores.AddAsync(editora);
        await _dbContext.SaveChangesAsync();

        return editora;
    }

    public async Task<bool> Apagar(int id)
    {
        editoraModel editoraPorId = await BuscarPorId(id);


        if (editoraPorId == null)
        {
            throw new Exception($"Usuário do ID: {id} não foi encontrado");
        }

        _dbContext.Editores.Remove(editoraPorId);
        await _dbContext.SaveChangesAsync();

        return true;
           
    }

    public async Task<editoraModel> Atualizar(editoraModel editora, int id)
    {
        editoraModel editoraPorId = await BuscarPorId(id);


        if (editoraPorId == null)
        {
            throw new Exception($"Usuário do ID: {id} não foi encontrado");
        }

        editoraPorId.nome = editora.nome;
        editoraPorId.localizacao = editora.localizacao;
        editoraPorId.anoFundacao = editora.anoFundacao;
        editoraPorId.livros = editora.livros;
   

        _dbContext.Editores.Update(editoraPorId);
        await _dbContext.SaveChangesAsync();

        return editoraPorId;
    }

   
}


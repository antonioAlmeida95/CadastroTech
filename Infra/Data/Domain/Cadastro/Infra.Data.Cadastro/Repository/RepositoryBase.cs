using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Infra.Data.Cadastro.Context;
using Infra.Data.Cadastro.Repository.Interfaces;
using Microsoft.EntityFrameworkCore.Query;

namespace Infra.Data.Cadastro.Repository;

public abstract class RepositoryBase<T> : IDisposable, IRepository<T> where T : class
{
    private readonly CadastroContext _contexto;

    public RepositoryBase(CadastroContext contexto)
    {
        _contexto = contexto;
    }
    
    /// <inheritdoc />
    public async Task AdicionarAsync(T entidade)
    {
        await _contexto.AddAsync(entidade);
    }

    /// <inheritdoc />
    public void Atualizar(T entidade)
    {
        _contexto.Update(entidade);
    }

    /// <inheritdoc />
    public void Remover(T entidade)
    {
        _contexto.Remove(entidade);
    }
    

    /// <summary>
    ///     Método para persistir todas as alterações no contexto
    /// </summary>
    /// <returns>Indicativo de sucesso da Operação</returns>
    protected async Task<bool> Commit()
    {
        try
        {
            var linhasAfetadas = await _contexto.SaveChangesAsync();
            return linhasAfetadas > 0;
        }
        catch (Exception e)
        {
            Console.WriteLine($"Falha: {e.Message}");
            return false;
        }
    }
    
    public void Dispose()
    {
        _contexto.Dispose();
    }

    /// <summary>
    ///     Método Base para obtenção dos dados
    /// </summary>
    /// <param name="expression">Expressão de filtragem</param>
    /// <param name="include">Expressão de Inclusão</param>
    /// <param name="track">Trackeamento das entidades</param>
    /// <param name="skip">Paginação da consulta</param>
    /// <param name="take">Tamanho da Listagem</param>
    /// <typeparam name="TX">Entidade Base</typeparam>
    /// <returns>Query com os dados</returns>
    protected IQueryable<TX> Query<TX>(Expression<Func<TX, bool>> expression = null, 
        Func<IQueryable<TX>, IIncludableQueryable<TX, object>> include = null, bool track = false,
        int? skip = null, int? take = null) where TX : class
    {
        var query = _contexto.GetQuery<TX>(track);

        if (expression != null)
            query = query.Where(expression);
        
        if (include != null)
            query = include(query);

        if (skip.HasValue)
            query = query.Skip(skip.Value);

        if (take.HasValue)
            query = query.Take(take.Value);

        return query;
    }
}
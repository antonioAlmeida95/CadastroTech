using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Domain.Cadastro;
using Infra.Data.Cadastro.Context;
using Infra.Data.Cadastro.Repository.Interfaces;
using Microsoft.EntityFrameworkCore.Query;

namespace Infra.Data.Cadastro.Repository;

public class ContatoRepository : RepositoryBase<Contato>, IContatoRepository
{
    public ContatoRepository(CadastroContext contexto) : base(contexto) { }

    /// <inheritdoc />
    public IEnumerable<CodigoDiscagem> ObterCodigosDiscagem(Expression<Func<CodigoDiscagem, bool>> predicate, 
        bool track = false)
    {
        return Query(predicate, track: track).ToList();
    }

    /// <inheritdoc />
    public IEnumerable<Contato> ObterContatos(Expression<Func<Contato, bool>> predicate,
        bool track = false, Func<IQueryable<Contato>, IIncludableQueryable<Contato, object>> include = null)
    {
        return Query(predicate, track: track, include: include).ToList();
    }

    /// <inheritdoc />
    public async Task<bool> IncluirContato(Contato contato)
    {
        await AdicionarAsync(contato);
        return await Commit();
    }

    /// <inheritdoc />
    public async Task<bool> AtualizarContato(Contato contato)
    {
        Atualizar(contato);
        return await Commit();
    }

    /// <inheritdoc />
    public async Task<bool> RemoverContato(Contato contato)
    {
        Remover(contato);
        return await Commit();
    }

    /// <inheritdoc />
    public Contato ObterContato(Expression<Func<Contato, bool>> predicate, bool track = false)
    {
        return Query(predicate, track: track).FirstOrDefault();
    }
}
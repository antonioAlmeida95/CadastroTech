using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
}
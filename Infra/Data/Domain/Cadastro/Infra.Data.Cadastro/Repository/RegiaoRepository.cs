using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Domain.Cadastro;
using Infra.Data.Cadastro.Context;
using Infra.Data.Cadastro.Repository.Interfaces;

namespace Infra.Data.Cadastro.Repository;

public class RegiaoRepository : RepositoryBase<Regiao>, IRegiaoRepository
{
    public RegiaoRepository(CadastroContext contexto) : base(contexto)
    {
    }

    /// <inheritdoc />
    public IEnumerable<Regiao> ObterRegioes(Expression<Func<Regiao, bool>> predicate)
    {
        return Query(predicate).ToList();
    }
}
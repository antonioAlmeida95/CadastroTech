using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Domain.Cadastro;

namespace Infra.Data.Cadastro.Repository.Interfaces;

public interface IRegiaoRepository
{
    /// <summary>
    ///     Método para obtenção das regiões por filtros
    /// </summary>
    /// <param name="predicate">Clausulas de Filtragem</param>
    /// <returns>Lista de Regiões</returns>
    IEnumerable<Regiao> ObterRegioes(Expression<Func<Regiao, bool>> predicate);
}
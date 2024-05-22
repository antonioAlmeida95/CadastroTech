using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Infra.Data.Cadastro.Repository.Interfaces;

public interface IRepository <T> where T : class
{
    /// <summary>
    ///     Método para inclusão assincrona de uma entidade
    /// </summary>
    /// <param name="entidade">Entidade para inclusão</param>
    Task AdicionarAsync(T entidade);

    /// <summary>
    ///     Método para atualização de uma entidade
    /// </summary>
    /// <param name="entidade">Entidade para atualização</param>
    void Atualizar(T entidade);

    /// <summary>
    ///     Método para remoção assincrona de uma entidade
    /// </summary>
    /// <param name="entidade">Entidade para remoção</param>
    void Remover(T entidade);

    /// <summary>
    ///     Método para obtenção da listagem de dados por filtros
    /// </summary>
    /// <param name="predicate">Filtros</param>
    /// <returns>Listagem de dados filtrados</returns>
    IEnumerable<T> ObterDados(Expression<Func<T, bool>> predicate);
}
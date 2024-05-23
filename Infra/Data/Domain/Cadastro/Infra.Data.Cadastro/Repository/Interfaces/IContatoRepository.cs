using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Domain.Cadastro;
using Microsoft.EntityFrameworkCore.Query;

namespace Infra.Data.Cadastro.Repository.Interfaces;

public interface IContatoRepository
{
    /// <summary>
    ///    Método para obtenção da listagem de código de discagem por filtros
    /// </summary>
    /// <param name="predicate">Clausulas de filtragem</param>
    /// <param name="track">Trackeamento da entidade</param>
    /// <returns>Lista de Codigo Discagem Filtrados</returns>
    IEnumerable<CodigoDiscagem> ObterCodigosDiscagem(Expression<Func<CodigoDiscagem, bool>> predicate, bool track = false);

    /// <summary>
    ///     Método para obtenção da listagem de contatos de discagem por filtros
    /// </summary>
    /// <param name="predicate">Clausulas de filtragem</param>
    /// <param name="track">Trackeamento da entidade</param>
    /// <param name="include">Clausulas de inclusão</param>
    /// <returns>Lista de Contatos Filtrados</returns>
    IEnumerable<Contato> ObterContatos(Expression<Func<Contato, bool>> predicate, bool track = false,
        Func<IQueryable<Contato>, IIncludableQueryable<Contato, object>> include = null);

    /// <summary>
    ///     Método para inclusão de um contato
    /// </summary>
    /// <param name="contato">Dados do contato</param>
    /// <returns>Indicativo de Sucesso</returns>
    Task<bool> IncluirContato(Contato contato);

    /// <summary>
    ///     Método para atualizar um contato
    /// </summary>
    /// <param name="contato">Dados do contato</param>
    /// <returns>Indicativo de Sucesso</returns>
    Task<bool> AtualizarContato(Contato contato);

    /// <summary>
    ///     Método para remover um contato
    /// </summary>
    /// <param name="contato">Dados do contato</param>
    /// <returns>Indicativo de Sucesso</returns>
    Task<bool> RemoverContato(Contato contato);

    /// <summary>
    ///     Método para obtenção de um contato por filtro
    /// </summary>
    /// <param name="predicate">Clausulas de filtragem</param>
    /// <param name="track">trackeamento da entidade</param>
    /// <returns>Dados do contato</returns>
    Contato ObterContato(Expression<Func<Contato, bool>> predicate, bool track = false);
}
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Cadastro.ViewModels;

namespace Application.Cadastro.Interfaces;

public interface IContatoAppService
{
    /// <summary>
    ///     Método para inclusão de um contato
    /// </summary>
    /// <param name="contatoViewModel">Dados do contato para inclusão</param>
    /// <returns>Identificador do contato cadastrado</returns>
    public Task<Guid> CadastarContato(CadastrarContatoViewModel contatoViewModel);

    /// <summary>
    ///     Método para atualizar um contato
    /// </summary>
    /// <param name="contatoViewModel">Dados do contato para atualizar</param>
    /// <returns>Indicativo de sucesso da operação</returns>
    public Task<bool> AtualizarContato(AtualizarContatoViewModel contatoViewModel);

    /// <summary>
    ///     Método para remoção de um contato por meio do identificador do contato
    /// </summary>
    /// <param name="contatoId">Identificador do contato</param>
    /// <returns>Indicativo de sucesso da operação</returns>
    public Task<bool> RemoverContato(Guid contatoId);

    /// <summary>
    ///     Método para obtenção dos contatos por filtro
    /// </summary>
    /// <param name="filtroViewModel">Dados para filtragem</param>
    /// <returns>Listagem de contatos filtrados</returns>
    public IEnumerable<ContatoViewModel> ObterListaContatos(ContatoFiltroViewModel filtroViewModel);

    /// <summary>
    ///     Método para obtenção do contato por meio do identificador
    /// </summary>
    /// <param name="contatoId">Identificador do contato</param>
    /// <returns>Dados do contato</returns>
    public ContatoViewModel ObterContatoPorId(Guid contatoId);
}
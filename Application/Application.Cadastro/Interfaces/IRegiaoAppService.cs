using System;
using System.Collections.Generic;
using Application.Cadastro.ViewModels;

namespace Application.Cadastro.Interfaces;

public interface IRegiaoAppService
{
    /// <summary>
    ///     Método para obtenção das Regiões por filtros
    /// </summary>
    /// <param name="regiaoFiltro"></param>
    /// <returns>Listagem de Regiões Filtradas</returns>
    IEnumerable<RegiaoViewModel> ObterListagemRegiao(RegiaoFiltroViewModel regiaoFiltro);

    /// <summary>
    ///     Método para obtenção daa Região por identificador
    /// </summary>
    /// <param name="regiaoId">Identificador da Região</param>
    /// <returns>Dados da Região</returns>
    RegiaoViewModel ObterRegiaoPorId(Guid regiaoId);
}
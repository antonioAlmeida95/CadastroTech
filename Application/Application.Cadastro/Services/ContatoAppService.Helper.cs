using System;
using System.Linq;
using System.Linq.Expressions;
using Application.Cadastro.ViewModels;
using Domain.Cadastro;
using Util.ExpressionExtension;

namespace Application.Cadastro.Services;

public partial class ContatoAppService
{
    /// <summary>
    ///     Método para atualizar os campos da entidade Contato
    /// </summary>
    /// <param name="contato">Dados existentes</param>
    /// <param name="contatoViewModel">Dados para atualização</param>
    private static void AtualizarCamposContato(ref Contato contato, AtualizarContatoViewModel contatoViewModel)
    {
        contato.AlterarCodigoDiscagemId(contatoViewModel.CodigoDiscagemId);
        contato.AlterarNome(contatoViewModel.Nome);
        contato.AlterarEmail(contatoViewModel.Email);
        contato.AlterarTelefone(contatoViewModel.Telefone);
    }

    /// <summary>
    ///     Método para a criação das clausulas de filtragem na consulta
    /// </summary>
    /// <param name="filtroViewModel">Filtros</param>
    /// <returns>Cláusulas de filtragem</returns>
    private static Expression<Func<Contato, bool>> GerarPredicateContato(ContatoFiltroViewModel filtroViewModel)
    {
        var predicate = ExpressionExtension.Query<Contato>();

        if (filtroViewModel.ContatosId.Any())
            predicate = filtroViewModel.ContatosId.Length == 1
                ? predicate.And(p => p.Id == filtroViewModel.ContatosId.First())
                : predicate.And(p => filtroViewModel.ContatosId.Contains(p.Id));

        if (!string.IsNullOrEmpty(filtroViewModel.Nome))
            predicate = predicate.And(p => p.Nome.ToUpper().Contains(filtroViewModel.Nome.ToUpper()));

        if (!string.IsNullOrEmpty(filtroViewModel.Email))
            predicate = predicate.And(p => p.Email.ToUpper().Contains(filtroViewModel.Email.ToUpper()));
        
        if (!string.IsNullOrEmpty(filtroViewModel.Telefone))
            predicate = predicate.And(p => p.Telefone.ToUpper().Contains(filtroViewModel.Telefone.ToUpper()));

        if (filtroViewModel.RegiaoId != null && filtroViewModel.RegiaoId != Guid.Empty)
            predicate = predicate.And(p => p.CodigoDiscagem.RegiaoId == filtroViewModel.RegiaoId);
        
        if (filtroViewModel.Ddd is > 0)
            predicate = predicate.And(p => p.CodigoDiscagem.RegiaoId == filtroViewModel.RegiaoId);
        
        return predicate;
    }
}
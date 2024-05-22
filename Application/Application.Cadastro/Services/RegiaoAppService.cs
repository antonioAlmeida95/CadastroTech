using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Application.Cadastro.Interfaces;
using Application.Cadastro.ViewModels;
using AutoMapper;
using Domain.Cadastro;
using Infra.Data.Cadastro.Repository.Interfaces;
using Util.ExpressionExtension;

namespace Application.Cadastro.Services;

public class RegiaoAppService : IRegiaoAppService
{
    private readonly IRegiaoRepository _regiaoRepository;
    private readonly IMapper _mapper;
    
    public RegiaoAppService(IRegiaoRepository regiaoRepository, IMapper mapper)
    {
        _regiaoRepository = regiaoRepository;
        _mapper = mapper;
    }
    
    public IEnumerable<RegiaoViewModel> ObterListagemRegiao(RegiaoFiltroViewModel regiaoFiltro)
    {
        var predicate = GerarPredicateRegiao(regiaoFiltro);
        var regioes = _regiaoRepository.ObterRegioes(predicate);
        return _mapper.Map<IEnumerable<RegiaoViewModel>>(regioes);
    }

    public RegiaoViewModel ObterRegiaoPorId(Guid regiaoId)
    {
        if (regiaoId == Guid.Empty) return null;

        var regiao = _regiaoRepository.ObterRegioes(r => r.Id == regiaoId).FirstOrDefault();

        return regiao != null ? _mapper.Map<RegiaoViewModel>(regiao) : null;
    }

    private static Expression<Func<Regiao, bool>> GerarPredicateRegiao(RegiaoFiltroViewModel regiaoFiltro)
    {
        var predicate = ExpressionExtension.Query<Regiao>();

        if (regiaoFiltro.RegiaoIds != null && regiaoFiltro.RegiaoIds.Any())
            predicate = regiaoFiltro.RegiaoIds.Length <= 1
                ? predicate.And(c => c.Id == regiaoFiltro.RegiaoIds.First())
                : predicate.And(c => regiaoFiltro.RegiaoIds.Contains(c.Id));

        if (!string.IsNullOrEmpty(regiaoFiltro.Nome))
            predicate = predicate.And(c => c.Nome.ToUpper().Contains(regiaoFiltro.Nome.ToUpper()));

        if (!string.IsNullOrEmpty(regiaoFiltro.Sigla))
            predicate = predicate.And(c => c.Sigla.ToUpper().Contains(regiaoFiltro.Sigla.ToUpper()));
        
        return predicate;
    }
}
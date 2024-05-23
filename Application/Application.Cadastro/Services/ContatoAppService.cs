using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Cadastro.Interfaces;
using Application.Cadastro.ViewModels;
using AutoMapper;
using Domain.Cadastro;
using Infra.Data.Cadastro.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Application.Cadastro.Services;

public partial class ContatoAppService : IContatoAppService
{
    private readonly IContatoRepository _contatoRepository;
    private readonly IMapper _mapper;

    public ContatoAppService(IContatoRepository contatoRepository, IMapper mapper)
    {
        _contatoRepository = contatoRepository;
        _mapper = mapper;
    }
    
    /// <inheritdoc />
    public async Task<Guid> CadastarContato(CadastrarContatoViewModel contatoViewModel)
    {
        var contato = _mapper.Map<Contato>(contatoViewModel);

        if (!contato.ValidarEntidade()) return Guid.Empty;

        var sucesso = await _contatoRepository.IncluirContato(contato);

        return sucesso ? contato.Id : Guid.Empty;
    }

    /// <inheritdoc />
    public async Task<bool> AtualizarContato(AtualizarContatoViewModel contatoViewModel)
    {
        var contatoExistente = _contatoRepository.ObterContato(p => p.Id == contatoViewModel.ContatoId, track: true);

        if (contatoExistente == null) return false;
        
        AtualizarCamposContato(ref contatoExistente, contatoViewModel);

        if (contatoExistente.ValidarEntidade()) return false;

        return await _contatoRepository.AtualizarContato(contatoExistente);
    }

    /// <inheritdoc />
    public async Task<bool> RemoverContato(Guid contatoId)
    {
        var contatoExistente = _contatoRepository.ObterContato(p => p.Id == contatoId, track: true);

        if (contatoExistente == null) return false;

        return  await _contatoRepository.RemoverContato(contatoExistente);
    }

    /// <inheritdoc />
    public IEnumerable<ContatoViewModel> ObterListaContatos(ContatoFiltroViewModel filtroViewModel)
    {
        var predicate = GerarPredicateContato(filtroViewModel);

        var contatos = _contatoRepository.ObterContatos(predicate,
            include: p => p.Include(c => c.CodigoDiscagem)
                .ThenInclude(c => c.Regiao));

        return contatos?.Any() == true
            ? _mapper.Map<IEnumerable<ContatoViewModel>>(contatos)
            : new List<ContatoViewModel>();
    }

    /// <inheritdoc />
    public ContatoViewModel ObterContatoPorId(Guid contatoId)
    {
        var contatoExistente = _contatoRepository.ObterContato(c => c.Id == contatoId);

        return contatoExistente != null ? _mapper.Map<ContatoViewModel>(contatoExistente) : null;
    }

    /// <inheritdoc />
    public IEnumerable<CodigoDiscagemViewModel> ObterListaCodigoDiscagem(CodigoDiscagemFiltroViewModel filtroViewModel)
    {
        var predicate = GerarPredicateCodigoDiscagem(filtroViewModel);

        var codigosDiscagem = _contatoRepository.ObterCodigosDiscagem(predicate);

        return codigosDiscagem?.Any() == true
            ? _mapper.Map<IEnumerable<CodigoDiscagemViewModel>>(codigosDiscagem)
            : new List<CodigoDiscagemViewModel>();
    }
}
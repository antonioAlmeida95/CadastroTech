using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Application.Cadastro.Services;
using Application.Cadastro.ViewModels;
using Infra.Data.Cadastro.Repository.Interfaces;
using Moq;
using RegiaoDomain = Domain.Cadastro.Regiao;

namespace Application.Cadastro.Test.Regiao;

[Collection(nameof(RegiaoAppServiceCollection))]
public partial class RegiaoAppServiceTests
{
    private readonly RegiaoAppService _regiaoAppService;
    private readonly RegiaoAppServiceFixture _appServiceFixture;

    public RegiaoAppServiceTests(RegiaoAppServiceFixture fixture)
    {
        _appServiceFixture = fixture;
        _regiaoAppService = _appServiceFixture.ObterRegiaoAppService();
    }

    [Fact(DisplayName = "Obtém a Regiao Por Id - Sucesso")]
    public void ObterRegiaoPorId_ObtemRegiaoPorId_Sucesso()
    {
        //Arrange
        var regiaoId = Guid.NewGuid();
        var regiao = RegiaoFactory.GerarRegiao(regiaoId, "Sul", "S");

        var regioes = new List<RegiaoDomain>
        {
            RegiaoFactory.GerarRegiao(),
            RegiaoFactory.GerarRegiao(),
            RegiaoFactory.GerarRegiao(),
            regiao
        };

        //Setup
        _appServiceFixture.SetupObterRegioes(regioes);
        
        //Act
        var response = _regiaoAppService.ObterRegiaoPorId(regiaoId);

        //Assert
        _appServiceFixture.Mocker.GetMock<IRegiaoRepository>()
            .Verify(s => s.ObterRegioes(It.IsAny<Expression<Func<RegiaoDomain, bool>>>()),
                Times.Once);

        Assert.NotNull(response);
        Assert.IsAssignableFrom<RegiaoViewModel>(response);
        Assert.Equal(regiaoId, response.RegiaoId);
        Assert.Equal(regiao.Nome, response.Nome);
        Assert.Equal(regiao.Sigla, response.Sigla);
    }
    
    [Fact(DisplayName = "Obtém a Regiao Por Id inexistente - Falha")]
    public void ObterRegiaoPorId_ObtemRegiaoPorIdInexistente_Falha()
    {
        //Arrange
        var regiaoId = Guid.NewGuid();

        var regioes = new List<RegiaoDomain>
        {
            RegiaoFactory.GerarRegiao(),
            RegiaoFactory.GerarRegiao(),
            RegiaoFactory.GerarRegiao()
        };

        //Setup
        _appServiceFixture.SetupObterRegioes(regioes);
        
        //Act
        var response = _regiaoAppService.ObterRegiaoPorId(regiaoId);

        //Assert
        _appServiceFixture.Mocker.GetMock<IRegiaoRepository>()
            .Verify(s => s.ObterRegioes(It.IsAny<Expression<Func<RegiaoDomain, bool>>>()),
                Times.Once);

        Assert.Null(response);
    }
    
    [Fact(DisplayName = "Obtém a Regiao Por Id inválido - Falha")]
    public void ObterRegiaoPorId_ObtemRegiaoPorIdInvalido_Falha()
    {
        //Arrange
        var regiaoId = Guid.Empty;
        
        //Act
        var response = _regiaoAppService.ObterRegiaoPorId(regiaoId);

        //Assert
        _appServiceFixture.Mocker.GetMock<IRegiaoRepository>()
            .Verify(s => s.ObterRegioes(It.IsAny<Expression<Func<RegiaoDomain, bool>>>()),
                Times.Never);

        Assert.Null(response);
    }

    [Theory(DisplayName = "Obtém Lista de regiões por filtros")]
    [MemberData(nameof(ParamsRegioesFiltros))]
    public void ObterListagemRegiao_ObtemListaRegioesPorFiltros_Sucesso(List<RegiaoDomain> regioes,
        RegiaoFiltroViewModel filtroViewModel, List<RegiaoDomain> regioesEsperadas, int quantidadeEsperada)
    {
        //Arrange
        //Setup
        _appServiceFixture.SetupObterRegioes(regioes);
        
        //Act
        var response = _regiaoAppService.ObterListagemRegiao(filtroViewModel).ToList();
        
        //Assert
        _appServiceFixture.Mocker.GetMock<IRegiaoRepository>()
            .Verify(s => s.ObterRegioes(It.IsAny<Expression<Func<RegiaoDomain, bool>>>()),
                Times.Once);
        
        Assert.NotNull(response);
        Assert.NotEmpty(response);
        Assert.IsAssignableFrom<IEnumerable<RegiaoViewModel>>(response);
        Assert.True(response.Count == quantidadeEsperada);

        Assert.Contains(regioesEsperadas, r => response.Any(re => 
            re.Nome == r.Nome && 
            re.Sigla == r.Sigla && 
            re.RegiaoId == r.Id));
    }
}
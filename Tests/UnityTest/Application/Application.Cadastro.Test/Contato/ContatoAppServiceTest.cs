using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Application.Cadastro.Services;
using Application.Cadastro.ViewModels;
using Domain.Cadastro;
using Infra.Data.Cadastro.Repository.Interfaces;
using Microsoft.EntityFrameworkCore.Query;
using Moq;
using ContatoDomain = Domain.Cadastro.Contato;

namespace Application.Cadastro.Test.Contato;

[Collection(nameof(ContatoAppServiceCollection))]
public partial class ContatoAppServiceTest
{
    private readonly ContatoAppService _contatoAppService;
    private readonly ContatoAppServiceFixture _appServiceFixture;

    public ContatoAppServiceTest(ContatoAppServiceFixture fixture)
    {
        _appServiceFixture = fixture;
        _contatoAppService = _appServiceFixture.ObterContatoAppService();
    }
    
    [Fact(DisplayName = "Cadastra um contato - Sucesso")]
    public async Task CadastarContato_CadastraUmContatoValido_Sucesso()
    {
       //Arrange
       var contato = ContatoFactory.GerarCadastrarContatoViewModel("Antonio", "7898999899",
           "teste@live.com", Guid.NewGuid());
       
       //Setup
       _appServiceFixture.SetupIncluirContato();
       
       //Act
       var contatoId = await _contatoAppService.CadastarContato(contato);
       
       //Assert
       _appServiceFixture.Mocker.GetMock<IContatoRepository>()
           .Verify(s => s.IncluirContato(It.Is<ContatoDomain>(c => 
               c.Nome.Equals(contato.Nome) &&
               c.Email.Equals(contato.Email) &&
               c.Telefone.Equals(contato.Telefone) &&
               c.CodigoDiscagemId == contato.CodigoDiscagemId)),
               Times.Once);
       
       Assert.True(contatoId != Guid.Empty);
    }
    
    [Theory(DisplayName = "Cadastra um contato com dados Inválidos - Falha")]
    [MemberData(nameof(ParamsContatoDadosInvalidos))]
    public async Task CadastarContato_CadastraUmContatoDadosInvalido_Falha(CadastrarContatoViewModel contato)
    {
        //Act
        var contatoId = await _contatoAppService.CadastarContato(contato);
       
        //Assert
        _appServiceFixture.Mocker.GetMock<IContatoRepository>()
            .Verify(s => s.IncluirContato(It.IsAny<ContatoDomain>()),
                Times.Never);
       
        Assert.True(contatoId == Guid.Empty);
    }
   
    [Fact(DisplayName = "Cadastra um contato - Falha")]
    public async Task CadastarContato_CadastraUmContatoValido_Falha()
    {
        //Arrange
        var contato = ContatoFactory.GerarCadastrarContatoViewModel("Antonio", "7898999899",
            "teste@live.com", Guid.NewGuid());
       
        //Setup
        _appServiceFixture.SetupIncluirContato(false);
       
        //Act
        var contatoId = await _contatoAppService.CadastarContato(contato);
       
        //Assert
        _appServiceFixture.Mocker.GetMock<IContatoRepository>()
            .Verify(s => s.IncluirContato(It.Is<ContatoDomain>(c => 
                    c.Nome.Equals(contato.Nome) &&
                    c.Email.Equals(contato.Email) &&
                    c.Telefone.Equals(contato.Telefone) &&
                    c.CodigoDiscagemId == contato.CodigoDiscagemId)),
                Times.Once);
       
        Assert.True(contatoId == Guid.Empty);
    }
    
    [Fact(DisplayName = "Atualiza um Contato - Sucesso")]
    public async Task AtualizarContato_AtualizaUmContato_Sucesso()
    {
        //Arrange
        var contatoId = Guid.NewGuid();
        var atualizarContato = ContatoFactory.GerarAtualizarContatoViewModel(contatoId: contatoId, nome: "Antonio L",
            telefone: "9898889998", email: "antonio@mail.com", codigoDiscagemId: Guid.NewGuid());

        var contatos = new List<ContatoDomain>
        {
            ContatoFactory.GerarContato(),
            ContatoFactory.GerarContato(),
            ContatoFactory.GerarContato(id: contatoId)
        };

        //Setup
        _appServiceFixture.SetupObterContato(contatos);
        _appServiceFixture.SetupAtualizarContato();
        
        //Act
        var response = await _contatoAppService.AtualizarContato(atualizarContato);
        
        //Assert
        _appServiceFixture.Mocker.GetMock<IContatoRepository>()
            .Verify(s => s.ObterContato(It.IsAny<Expression<Func<ContatoDomain, bool>>>(), It.IsAny<bool>()),
                Times.Once);
        
        _appServiceFixture.Mocker.GetMock<IContatoRepository>()
            .Verify(s => s.AtualizarContato(It.Is<ContatoDomain>(c => 
                    c.Nome.Equals(atualizarContato.Nome) &&
                    c.Email.Equals(atualizarContato.Email) &&
                    c.Telefone.Equals(atualizarContato.Telefone) &&
                    c.Id == atualizarContato.ContatoId &&
                    c.CodigoDiscagemId == atualizarContato.CodigoDiscagemId)),
                Times.Once);
        
        Assert.True(response);
    }
    
    [Fact(DisplayName = "Atualiza um Contato Inexistente - Falha")]
    public async Task AtualizarContato_AtualizaUmContatoInexistente_Falha()
    {
        //Arrange
        var contatoId = Guid.NewGuid();
        var atualizarContato = ContatoFactory.GerarAtualizarContatoViewModel(contatoId: contatoId, nome: "Antonio L",
            telefone: "9898889998", email: "antonio@mail.com", codigoDiscagemId: Guid.NewGuid());

        var contatos = new List<ContatoDomain>
        {
            ContatoFactory.GerarContato(),
            ContatoFactory.GerarContato(),
            ContatoFactory.GerarContato()
        };

        //Setup
        _appServiceFixture.SetupObterContato(contatos);
        
        //Act
        var response = await _contatoAppService.AtualizarContato(atualizarContato);
        
        //Assert
        _appServiceFixture.Mocker.GetMock<IContatoRepository>()
            .Verify(s => s.ObterContato(It.IsAny<Expression<Func<ContatoDomain, bool>>>(), It.IsAny<bool>()),
                Times.Once);
        
        _appServiceFixture.Mocker.GetMock<IContatoRepository>()
            .Verify(s => s.AtualizarContato(It.IsAny<ContatoDomain>()),
                Times.Never);
        
        Assert.False(response);
    }
    
    [Theory(DisplayName = "Atualiza um Contato com Dados Inválidos - Sucesso")]
    [MemberData(nameof(ParamsAtualizarContatoDadosInvalidos))]
    public async Task AtualizarContato_AtualizaUmContatoDadosInvalidos_Falha(List<ContatoDomain> contatos,
        AtualizarContatoViewModel atualizarContato)
    {
        //Setup
        _appServiceFixture.SetupObterContato(contatos);
        
        //Act
        var response = await _contatoAppService.AtualizarContato(atualizarContato);
        
        //Assert
        _appServiceFixture.Mocker.GetMock<IContatoRepository>()
            .Verify(s => s.ObterContato(It.IsAny<Expression<Func<ContatoDomain, bool>>>(), It.IsAny<bool>()),
                Times.Once);
        
        _appServiceFixture.Mocker.GetMock<IContatoRepository>()
            .Verify(s => s.AtualizarContato(It.IsAny<ContatoDomain>()),
                Times.Never);
        
        Assert.False(response);
    }
    
    [Fact(DisplayName = "Atualizar um Contato - Falha")]
    public async Task AtualizarContato_AtualizaUmContato_Falha()
    {
        //Arrange
        var contatoId = Guid.NewGuid();
        var atualizarContato = ContatoFactory.GerarAtualizarContatoViewModel(contatoId: contatoId, nome: "Antonio L",
            telefone: "9898889998", email: "antonio@mail.com", codigoDiscagemId: Guid.NewGuid());

        var contatos = new List<ContatoDomain>
        {
            ContatoFactory.GerarContato(),
            ContatoFactory.GerarContato(),
            ContatoFactory.GerarContato(id: contatoId)
        };

        //Setup
        _appServiceFixture.SetupObterContato(contatos);
        _appServiceFixture.SetupAtualizarContato(false);
        
        //Act
        var response = await _contatoAppService.AtualizarContato(atualizarContato);
        
        //Assert
        _appServiceFixture.Mocker.GetMock<IContatoRepository>()
            .Verify(s => s.ObterContato(It.IsAny<Expression<Func<ContatoDomain, bool>>>(), It.IsAny<bool>()),
                Times.Once);
        
        _appServiceFixture.Mocker.GetMock<IContatoRepository>()
            .Verify(s => s.AtualizarContato(It.Is<ContatoDomain>(c => 
                    c.Nome.Equals(atualizarContato.Nome) &&
                    c.Email.Equals(atualizarContato.Email) &&
                    c.Telefone.Equals(atualizarContato.Telefone) &&
                    c.Id == atualizarContato.ContatoId &&
                    c.CodigoDiscagemId == atualizarContato.CodigoDiscagemId)),
                Times.Once);
        
        Assert.False(response);
    }
    
    [Fact(DisplayName = "Remove um Contato - Sucesso")]
    public async Task RemoverContato_RemoveUmContato_Sucesso()
    {
        //Arrange
        var contatoId = Guid.NewGuid();

        var contatos = new List<ContatoDomain>
        {
            ContatoFactory.GerarContato(),
            ContatoFactory.GerarContato(),
            ContatoFactory.GerarContato(id: contatoId)
        };

        //Setup
        _appServiceFixture.SetupObterContato(contatos);
        _appServiceFixture.SetupRemoverContato();
        
        //Act
        var response = await _contatoAppService.RemoverContato(contatoId);
        
        //Assert
        _appServiceFixture.Mocker.GetMock<IContatoRepository>()
            .Verify(s => s.ObterContato(It.IsAny<Expression<Func<ContatoDomain, bool>>>(), It.Is<bool>(b => b)),
                Times.Once);

        _appServiceFixture.Mocker.GetMock<IContatoRepository>()
            .Verify(s => s.RemoverContato(It.Is<ContatoDomain>(c => c.Id == contatoId)), 
                Times.Once);
        
        Assert.True(response);
    }
    
    [Fact(DisplayName = "Remove um Contato Inexistente - Falha")]
    public async Task RemoverContato_RemoveUmContatoInexistente_Falha()
    {
        //Arrange
        var contatoId = Guid.NewGuid();

        var contatos = new List<ContatoDomain>
        {
            ContatoFactory.GerarContato(),
            ContatoFactory.GerarContato()
        };

        //Setup
        _appServiceFixture.SetupObterContato(contatos);
        
        //Act
        var response = await _contatoAppService.RemoverContato(contatoId);
        
        //Assert
        _appServiceFixture.Mocker.GetMock<IContatoRepository>()
            .Verify(s => s.ObterContato(It.IsAny<Expression<Func<ContatoDomain, bool>>>(), It.Is<bool>(b => b)),
                Times.Once);

        _appServiceFixture.Mocker.GetMock<IContatoRepository>()
            .Verify(s => s.RemoverContato(It.Is<ContatoDomain>(c => c.Id == contatoId)),
                Times.Never);
        
        Assert.False(response);
    }
    
    [Fact(DisplayName = "Remove um Contato - falha")]
    public async Task RemoverContato_RemoveUmContato_Falha()
    {
        //Arrange
        var contatoId = Guid.NewGuid();

        var contatos = new List<ContatoDomain>
        {
            ContatoFactory.GerarContato(),
            ContatoFactory.GerarContato(),
            ContatoFactory.GerarContato(id: contatoId)
        };

        //Setup
        _appServiceFixture.SetupObterContato(contatos);
        _appServiceFixture.SetupRemoverContato(false);
        
        //Act
        var response = await _contatoAppService.RemoverContato(contatoId);
        
        //Assert
        _appServiceFixture.Mocker.GetMock<IContatoRepository>()
            .Verify(s => s.ObterContato(It.IsAny<Expression<Func<ContatoDomain, bool>>>(), It.Is<bool>(b => b)),
                Times.Once);

        _appServiceFixture.Mocker.GetMock<IContatoRepository>()
            .Verify(s => s.RemoverContato(It.Is<ContatoDomain>(c => c.Id == contatoId)), 
                Times.Once);
        
        Assert.False(response);
    }
    
    [Theory(DisplayName = "Obtém lista de Contatos por Filtros - Sucesso")]
    [MemberData(nameof(ParamsContatosFiltros))]
    public void ObterListaContatos_ObtemListaContatosPorFiltros_Sucesso(List<ContatoDomain> contatos, 
        ContatoFiltroViewModel filtros, List<ContatoDomain> contatosEsperados, int quantidadeEsperada)
    {
        //Setup
        _appServiceFixture.SetupObterContatos(contatos);
        
        //Act
        var response = _contatoAppService.ObterListaContatos(filtros).ToList();
        
        //Assert
        _appServiceFixture.Mocker.GetMock<IContatoRepository>()
            .Verify(s => s.ObterContatos(It.IsAny<Expression<Func<ContatoDomain, bool>>>(),
                It.IsAny<bool>(),
                It.IsAny<Func<IQueryable<ContatoDomain>, IIncludableQueryable<ContatoDomain, object>>>()),
                Times.Once());
        
        Assert.IsAssignableFrom<IEnumerable<ContatoViewModel>>(response);
        Assert.Equal(quantidadeEsperada, response.Count);
        Assert.Contains(contatosEsperados, c => response.Any(r => 
                c.Nome.Equals(r.Nome) &&
                c.Telefone.Equals(r.Telefone) &&
                c.Email.Equals(r.Email)));
    }
    
    [Fact(DisplayName = "Obtém um contato por Id - Sucesso")]
    public void ObterContatoPorId_ObtemUmContatoPorId_Sucesso()
    {
        //Arrange
        var contatoId = Guid.NewGuid();
        var contato = ContatoFactory.GerarContato(id: contatoId, nome: "Jose", telefone: "898899999", 
            email: "teste@mail.com");

        var contatos = new List<ContatoDomain>
        {
            ContatoFactory.GerarContato(),
            ContatoFactory.GerarContato(),
            contato,
            ContatoFactory.GerarContato(),
            ContatoFactory.GerarContato()
        };

        //Setup
        _appServiceFixture.SetupObterContato(contatos);
        
        //Act
        var response = _contatoAppService.ObterContatoPorId(contatoId);
        
        //Assert
        _appServiceFixture.Mocker.GetMock<IContatoRepository>()
            .Verify(s => s.ObterContato(It.IsAny<Expression<Func<ContatoDomain, bool>>>(), It.Is<bool>(b => !b)),
                Times.Once);

        Assert.NotNull(response);
        Assert.Equal(contato.Nome, response.Nome);
        Assert.Equal(contato.Email, response.Email);
        Assert.Equal(contato.Telefone, response.Telefone);
    }
    
    [Fact(DisplayName = "Obtém um contato por Id - Falha")]
    public void ObterContatoPorId_ObtemUmContatoPorId_Falha()
    {
        //Arrange
        var contatoId = Guid.NewGuid();
        var contatos = new List<ContatoDomain>
        {
            ContatoFactory.GerarContato(),
            ContatoFactory.GerarContato(),
            ContatoFactory.GerarContato(),
            ContatoFactory.GerarContato()
        };

        //Setup
        _appServiceFixture.SetupObterContato(contatos);
        
        //Act
        var response = _contatoAppService.ObterContatoPorId(contatoId);
        
        //Assert
        _appServiceFixture.Mocker.GetMock<IContatoRepository>()
            .Verify(s => s.ObterContato(It.IsAny<Expression<Func<ContatoDomain, bool>>>(), It.Is<bool>(b => !b)),
                Times.Once);

        Assert.Null(response);
    }
    
    //ObterListaCodigoDiscagem - Sucesso
    [Theory(DisplayName = "Obtém a lista codigo discagem por filtros - Sucesso")]
    [MemberData(nameof(ParamsCodigoDiscagemFiltros))]
    public void ObterListaCodigoDiscagem_ObtemListaCodigoDiscagemPorFiltros_Sucesso(List<CodigoDiscagem> codigosDiscagem,
        CodigoDiscagemFiltroViewModel filtros, List<CodigoDiscagem> codigosEsperados, int quantidadeEsperada)
    {
        //Setup
        _appServiceFixture.SetupObterCodigosDiscagem(codigosDiscagem);
        
        //Act
        var response = _contatoAppService.ObterListaCodigoDiscagem(filtros).ToList();
        
        //Assert
        _appServiceFixture.Mocker.GetMock<IContatoRepository>()
            .Verify(s => s.ObterCodigosDiscagem(It.IsAny<Expression<Func<CodigoDiscagem, bool>>>(), It.IsAny<bool>()),
                Times.Once());
        
        Assert.IsAssignableFrom<IEnumerable<CodigoDiscagemViewModel>>(response);
        Assert.Equal(quantidadeEsperada, response.Count);
        Assert.Contains(codigosEsperados, c => response.Any(r => 
            c.Ddd.Equals(r.Ddd) &&
            c.Id == r.CodigoDiscagemId));
    }
}
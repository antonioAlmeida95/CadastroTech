using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Application.Cadastro.AutoMapper;
using Application.Cadastro.Services;
using Domain.Cadastro;
using Infra.Data.Cadastro.Repository.Interfaces;
using Microsoft.EntityFrameworkCore.Query;
using Moq;
using Moq.AutoMock;
using ContatoDomain = Domain.Cadastro.Contato;

namespace Application.Cadastro.Test.Contato;

[CollectionDefinition(nameof(ContatoAppServiceCollection))]
public class ContatoAppServiceCollection : ICollectionFixture<ContatoAppServiceFixture> { }
public class ContatoAppServiceFixture
{
    public AutoMocker Mocker;
    public ContatoAppService ContatoAppService;

    public ContatoAppService ObterContatoAppService()
    {
        Mocker = new AutoMocker();
        
        Mocker.Use(AutoMapperConfiguration.RegisterMappings().CreateMapper());

       ContatoAppService = Mocker.CreateInstance<ContatoAppService>();

        return ContatoAppService;
    }

    public void SetupIncluirContato(bool sucesso = true)
    {
        Mocker.GetMock<IContatoRepository>()
            .Setup(s => s.IncluirContato(It.IsAny<ContatoDomain>()))
            .ReturnsAsync(sucesso);
    }

    public void SetupObterContato(IEnumerable<ContatoDomain> contatos)
    {
        Mocker.GetMock<IContatoRepository>()
            .Setup(s => s.ObterContato(It.IsAny<Expression<Func<ContatoDomain, bool>>>(), It.IsAny<bool>()))
            .Returns<Expression<Func<ContatoDomain, bool>>, bool>((exp, _) => contatos.FirstOrDefault(exp.Compile()));
    }
    
    public void SetupAtualizarContato(bool sucesso = true)
    {
        Mocker.GetMock<IContatoRepository>()
            .Setup(s => s.AtualizarContato(It.IsAny<ContatoDomain>()))
            .ReturnsAsync(sucesso);
    }
    
    public void SetupRemoverContato(bool sucesso = true)
    {
        Mocker.GetMock<IContatoRepository>()
            .Setup(s => s.RemoverContato(It.IsAny<ContatoDomain>()))
            .ReturnsAsync(sucesso);
    }

    public void SetupObterContatos(IEnumerable<ContatoDomain> contatos)
    {
        Mocker.GetMock<IContatoRepository>()
            .Setup(s => s.ObterContatos(It.IsAny<Expression<Func<ContatoDomain, bool>>>(),
                It.IsAny<bool>(),
                It.IsAny<Func<IQueryable<ContatoDomain>, IIncludableQueryable<ContatoDomain, object>>>()))
            .Returns<Expression<Func<ContatoDomain, bool>>, bool, Func<IQueryable<ContatoDomain>,
                IIncludableQueryable<ContatoDomain, object>>>((exp, _, _) => contatos.Where(exp.Compile()).ToList());
    }

    public void SetupObterCodigosDiscagem(IEnumerable<CodigoDiscagem> codigosDiscagem)
    {
        Mocker.GetMock<IContatoRepository>()
            .Setup(s => s.ObterCodigosDiscagem(It.IsAny<Expression<Func<CodigoDiscagem, bool>>>(), It.IsAny<bool>()))
            .Returns<Expression<Func<CodigoDiscagem, bool>>, bool>((exp, _) =>
                codigosDiscagem.Where(exp.Compile()).ToList());
    }
}
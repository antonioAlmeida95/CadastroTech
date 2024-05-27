using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Application.Cadastro.AutoMapper;
using Application.Cadastro.Services;
using Infra.Data.Cadastro.Repository.Interfaces;
using Moq;
using Moq.AutoMock;
using RegiaoDomain = Domain.Cadastro.Regiao;

namespace Application.Cadastro.Test.Regiao;

[CollectionDefinition(nameof(RegiaoAppServiceCollection))]
public class RegiaoAppServiceCollection : ICollectionFixture<RegiaoAppServiceFixture> { }
public class RegiaoAppServiceFixture
{
    public AutoMocker Mocker;
    public RegiaoAppService RegiaoAppService;

    public RegiaoAppService ObterRegiaoAppService()
    {
        Mocker = new AutoMocker();
        
        Mocker.Use(AutoMapperConfiguration.RegisterMappings().CreateMapper());

        RegiaoAppService = Mocker.CreateInstance<RegiaoAppService>();

        return RegiaoAppService;
    }

    public void SetupObterRegioes(IEnumerable<RegiaoDomain> regioes)
    {
        Mocker.GetMock<IRegiaoRepository>()
            .Setup(s => s.ObterRegioes(It.IsAny<Expression<Func<RegiaoDomain, bool>>>()))
            .Returns<Expression<Func<RegiaoDomain, bool>>>(exp => regioes.Where(exp.Compile()).ToList());
    }
}
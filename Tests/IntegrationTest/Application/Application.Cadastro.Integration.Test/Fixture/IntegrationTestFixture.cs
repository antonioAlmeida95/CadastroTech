using System;
using System.Net.Http;
using Application.Cadastro.Integration.Test.Factory;
using Microsoft.AspNetCore.Mvc.Testing;
using Service.Cadastro;
using Xunit;

namespace Application.Cadastro.Integration.Test.Fixture;

[CollectionDefinition(nameof(IntegrationApiTestFixtureCollection))]
public class IntegrationApiTestFixtureCollection : ICollectionFixture<IntegrationTestFixture<StartupTest>> { }

public class IntegrationTestFixture<T> : IDisposable where T : class
{
    private readonly IntegrationTestFactory<T> _factory;
    public HttpClient Client;
    
    public IntegrationTestFixture()
    {
        var clientOptions = new WebApplicationFactoryClientOptions()
        {
            HandleCookies = false,
            BaseAddress = new Uri("http://localhost:5000"),
            AllowAutoRedirect = true,
            MaxAutomaticRedirections = 7
        };

        _factory = new IntegrationTestFactory<T>();
        Client = _factory.CreateClient(clientOptions);
    }
    
    public void Dispose()
    {
        Client.Dispose();
        _factory.Dispose();
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Cadastro.Integration.Test.Fixture;
using Application.Cadastro.ViewModels;
using Newtonsoft.Json;
using Service.Cadastro;
using Xunit;

namespace Application.Cadastro.Integration.Test.Regiao;

[Collection(nameof(IntegrationApiTestFixtureCollection))]
public class RegiaoControllerTests
{
    private readonly IntegrationTestFixture<StartupTest> _integrationTestFixture;
    
    public RegiaoControllerTests(IntegrationTestFixture<StartupTest> integrationTestFixture)
    {
        _integrationTestFixture = integrationTestFixture;
    }

    [Fact(Skip = "Skip para o deploy do projeto")]
    public async Task Get_ObtemRegioesPorFiltro_Sucesso()
    {
        //Arrange
        const string nome = "Nor";
        const string url = $"Regiao/PorFiltro?Nome={nome}";
        
        //Act
        var request = await _integrationTestFixture.Client.GetAsync(url);
        var response = await request.Content.ReadAsStringAsync();
        var data = JsonConvert.DeserializeObject<IEnumerable<RegiaoViewModel>>(response).ToList();
        
        //Assert
        Assert.NotEmpty(data);
        Assert.IsAssignableFrom<IEnumerable<RegiaoViewModel>>(data);
        Assert.All(data, d => Assert.Contains(nome, d.Nome));
    }
    
    [Fact(Skip = "Skip para o deploy do projeto")]
    public async Task Get_ObtemRegioesPorId_Sucesso()
    {
        //Arrange
        var regiaoId = Guid.Parse("4962c256-0850-455f-8a85-617e9ee941c0");
        var url = $"http://localhost:5000/Regiao/PorId/{regiaoId}";
        
        //Act
        var request = await _integrationTestFixture.Client.GetAsync(url);
        var response = await request.Content.ReadAsStringAsync();
        var data = JsonConvert.DeserializeObject<RegiaoViewModel>(response);
        
        //Assert
        Assert.NotNull(data);
        Assert.IsAssignableFrom<RegiaoViewModel>(data);
        Assert.Equal(regiaoId, data.RegiaoId);
    }
}
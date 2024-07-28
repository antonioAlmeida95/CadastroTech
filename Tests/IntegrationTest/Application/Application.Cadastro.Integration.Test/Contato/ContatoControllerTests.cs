using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Application.Cadastro.Integration.Test.Factory;
using Application.Cadastro.Integration.Test.Fixture;
using Application.Cadastro.ViewModels;
using Newtonsoft.Json;
using Service.Cadastro;
using Xunit;

namespace Application.Cadastro.Integration.Test.Contato;

[Collection(nameof(IntegrationApiTestFixtureCollection))]
public class ContatoControllerTests
{
    private readonly IntegrationTestFixture<StartupTest> _integrationTestFixture;

    public ContatoControllerTests(IntegrationTestFixture<StartupTest> integrationTestFixture)
    {
        _integrationTestFixture = integrationTestFixture;
    }

    [Fact(Skip = "Skip para o deploy do projeto")]
    public async Task Post_CadastraUmContato_Sucesso()
    {
        //Arrange
        var jsonContent = JsonConvert.SerializeObject(FactoryTest.GerarCadastrarContatoViewModel()); 
        
        var contentString = new StringContent(jsonContent, Encoding.UTF8, "application/json");
        contentString.Headers.ContentType = new 
            MediaTypeHeaderValue("application/json");
        
        //Act
        var request = await _integrationTestFixture.Client.PostAsync("Cadastro/Cadastrar", contentString);
        var response = await request.Content.ReadAsStringAsync();
        
        //Assert
        response = response.Replace("\"", "");
        var success = Guid.TryParse(response, out var id);
        
        Assert.Equal(HttpStatusCode.OK, request.StatusCode);
        Assert.True(success);
        Assert.NotEqual(Guid.Empty, id);
    }

    [Fact(Skip = "Skip para o deploy do projeto")]
    public async Task Get_ObtemCodigoDiscagemPorFiltros_Sucesso()
    {
        //Arrange
        const int ddd = 79;
        var url = $"Cadastro/CodigoDiscagem/PorFiltros?Ddd={ddd}";

        //Act
        var request = await _integrationTestFixture.Client.GetAsync(url);
        var response = await request.Content.ReadAsStringAsync();
        var data = JsonConvert.DeserializeObject<IEnumerable<CodigoDiscagemViewModel>>(response).ToList();

        //Assert
        Assert.NotEmpty(data);
        Assert.IsAssignableFrom<IEnumerable<CodigoDiscagemViewModel>>(data);
        Assert.All(data, d => Assert.Equal(ddd, d.Ddd));
    }
}
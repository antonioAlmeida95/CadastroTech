using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;

namespace Application.Cadastro.Integration.Test.Factory;

public class IntegrationTestFactory<T> : WebApplicationFactory<T> where T : class
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.UseStartup<T>();
        builder.UseEnvironment("Staging");
    }
}
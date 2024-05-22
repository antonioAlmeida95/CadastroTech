using Infra.Data.Cadastro.Context;
using Infra.Data.Cadastro.Repository;
using Infra.Data.Cadastro.Repository.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Infra.CrossCutting.IoC.Domain.Cadastro;

public class NativeInjectorBootStrapper
{
    public static void RegisterServices(IServiceCollection services)
    {
        services.AddScoped(sp =>
        {
            var context = new CadastroContext();
            return context;
        });
        
        services.AddScoped<IContatoRepository, ContatoRepository>();
        services.AddScoped<IRegiaoRepository, RegiaoRepository>();
    }
    
}
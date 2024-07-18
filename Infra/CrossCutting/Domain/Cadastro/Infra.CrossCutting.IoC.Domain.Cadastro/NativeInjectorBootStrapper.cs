using System.Linq;
using Application.Cadastro.AutoMapper;
using Application.Cadastro.Interfaces;
using Application.Cadastro.Services;
using Infra.Data.Cadastro.Context;
using Infra.Data.Cadastro.Repository;
using Infra.Data.Cadastro.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infra.CrossCutting.IoC.Domain.Cadastro;

public class NativeInjectorBootStrapper
{
    public static void RegisterServices(IServiceCollection services)
    {
        //Repositorios
        services.AddScoped(sp =>
        {
            var context = new CadastroContext();
            
            if (context.Database.GetPendingMigrations().Any())
                context.Database.Migrate();
            
            return context;
        });
        
        services.AddScoped<IContatoRepository, ContatoRepository>();
        services.AddScoped<IRegiaoRepository, RegiaoRepository>();
        
        //Mapper
        services.AddAutoMapper(typeof(AutoMapperConfiguration));
        
        //Applications
        services.AddScoped<IRegiaoAppService, RegiaoAppService>();
        services.AddScoped<IContatoAppService, ContatoAppService>();
    }
    
}
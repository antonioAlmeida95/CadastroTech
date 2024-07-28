using System;
using System.IO;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.Text.Json.Serialization;
using Infra.CrossCutting.IoC.Domain.Cadastro;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Prometheus;

namespace Service.Cadastro
{
    /// <summary>
    /// Statup.
    /// Classe Responsavel pela inicialização da API.
    /// </summary>
    public class StartupTest
    {
        /// <summary>
        /// Configurações da aplicação.
        /// </summary>
        public IConfiguration Configuration { get; }
        /// <summary>
        /// Variável de ambiente.
        /// </summary>
        public IWebHostEnvironment CurrentEnvironment { get; }

        /// <summary>
        /// COnstrutor da Classe.
        /// </summary>
        /// <param name="configuration"></param>
        /// <param name="env"></param>
        public StartupTest(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            CurrentEnvironment = env;
        }
        /// <summary>
        /// Método de definições e configurações dos serviços.
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            services = ConfigureNativeInjector(services);
           
            services.AddHttpClient();
            services.AddControllers()
                .AddJsonOptions(o => o.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
        }

        /// <summary>
        /// Método de definições e configurações do APP.
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsStaging())
            {
                app.UseDeveloperExceptionPage();
                app.UseCors("SiteCorsPolicy");
            }
            
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseEndpoints(endpoints => endpoints.MapControllers());
        }

        private static IServiceCollection ConfigureNativeInjector(IServiceCollection services)
        {
            NativeInjectorBootStrapper.RegisterServices(services);
            return services;
        }
        
    }
}
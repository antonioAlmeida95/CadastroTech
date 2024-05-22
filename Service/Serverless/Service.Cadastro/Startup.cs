using System;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.OpenApi.Models;
using System.Net;
using System.Net.Mime;
using System.Reflection;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Service.Cadastro
{
    /// <summary>
    /// Statup.
    /// Classe Responsavel pela inicialização da API.
    /// </summary>
    public class Startup
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
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
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
            services = ConfigureServer(services);
            services = ConfigureAppSettings(services);
           
            services.AddHttpClient();

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Documentação API",
                    Version = "v1",
                    Description = "API desafio 01 pos tech da avaliação técnica.",
                    Contact = new OpenApiContact
                    {
                        Name = "Antonio Lucas de Almeida",
                        Url = new Uri("https://github.com/LucasStark95")
                    }

                });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                options.IncludeXmlComments(xmlPath);


            });

            services.AddControllers()
                .AddJsonOptions(o =>
                {
                    o.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
                })
                .ConfigureApiBehaviorOptions(options =>
                {
                    options.InvalidModelStateResponseFactory = _ =>
                    {
                        var result = new BadRequestObjectResult("Os valores informados não são válidos.");
                        result.ContentTypes.Add(MediaTypeNames.Application.Json);
                        result.StatusCode = (int)HttpStatusCode.PreconditionFailed;

                        return result;
                    };
                });
            
        }

        /// <summary>
        /// Método de definições e configurações do APP.
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseCors("SiteCorsPolicy");
            }

            app.UseHttpsRedirection();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.RoutePrefix = string.Empty;
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Documentação Api");
            });

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private IServiceCollection ConfigureServer(IServiceCollection services)
        {
            // If using Kestrel:
            services.Configure<KestrelServerOptions>(options =>
            {
                options.AllowSynchronousIO = true;
            });

            // If using IIS:
            services.Configure<IISServerOptions>(options =>
            {
                options.AllowSynchronousIO = true;
            });

            return services;
        }

        private IServiceCollection ConfigureAppSettings(IServiceCollection services)
        {
            var basePath = Directory.GetCurrentDirectory() + "/Config";
            
            var appSettings = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile("appsettings.json")
                .Build();
            
            var connectionString = appSettings.GetConnectionString("DefaultConnection");
            
            
            return services;
        }
        
    }
}
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
            services = ConfigureNativeInjector(services);
           
            services.AddHttpClient();
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Documentação API",
                    Version = "v2",
                    Description = "API desafio 02 pos tech da avaliação técnica.",
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
                .AddJsonOptions(o => o.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
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
            
            ConfigurePrometheus(app);

            app.UseRouting();
            app.UseEndpoints(endpoints => endpoints.MapControllers());
        }

        private static void ConfigurePrometheus(IApplicationBuilder app)
        {
            var counter = Metrics.CreateCounter("ApiMetric", "Metricas das Aplicação", new CounterConfiguration
            {
                LabelNames = ["method", "endpoint"]
            });

            app.Use((context, next) =>
            {
                counter.WithLabels(context.Request.Method, context.Request.Path).Inc();
                return next();
            });

            app.UseMetricServer();
            app.UseHttpMetrics();
        }

        private static IServiceCollection ConfigureNativeInjector(IServiceCollection services)
        {
            NativeInjectorBootStrapper.RegisterServices(services);
            return services;
        }
        
    }
}
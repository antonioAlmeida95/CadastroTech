using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Infra.Data.Cadastro.Context;

public partial class CadastroContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if(optionsBuilder.IsConfigured) return;

        if (string.IsNullOrEmpty(_connectionString))
            _connectionString = LoadConnectionString();
        
        ArgumentException.ThrowIfNullOrWhiteSpace(_connectionString);

        optionsBuilder.UseNpgsql(_connectionString);
    }
    
    /// <summary>
    ///     Método para obtenção da string de conexão do arquivo de conexão
    /// </summary>
    /// <param name="connectionStringName">Identificador do campo</param>
    /// <returns>String de Conexão</returns>
    private static string LoadConnectionString(string connectionStringName = "DefaultConnection")
    {
        var config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory() + "//Config")
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: false)
            .Build();

        var connStr = config.GetConnectionString(connectionStringName);
        return connStr ?? string.Empty;
    }
}
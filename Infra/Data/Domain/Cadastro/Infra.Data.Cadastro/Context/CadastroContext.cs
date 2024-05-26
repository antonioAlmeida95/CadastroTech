using Domain.Cadastro;
using Infra.Data.Cadastro.Context.Interface;
using Infra.Data.Cadastro.Mappings;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.Cadastro.Context;

public partial class CadastroContext : BaseContext
{
    private string _connectionString;
    public CadastroContext(string connectionString = null) => _connectionString = connectionString;

    public DbSet<Contato> Contato { get; set; }
    public DbSet<CodigoDiscagem> CodigoDiscagem { get; set; }
    public DbSet<Regiao> Regiao { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ContatoMapping());
        modelBuilder.ApplyConfiguration(new CodigoDiscagemMapping());
        modelBuilder.ApplyConfiguration(new RegiaoMapping());
    }
}
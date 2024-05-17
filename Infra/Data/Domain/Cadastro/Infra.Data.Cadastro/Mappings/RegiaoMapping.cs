using Domain.Cadastro;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Data.Cadastro.Mappings;

public class RegiaoMapping : IEntityTypeConfiguration<Regiao>
{
    public void Configure(EntityTypeBuilder<Regiao> builder)
    {
        builder.Property(x => x.Id)
            .HasColumnName("Reg_RegiaoId");

        builder.Property(x => x.Nome)
            .HasColumnName("Reg_Nome")
            .IsRequired();
        
        builder.Property(x => x.Sigla)
            .HasColumnName("Reg_Sigla")
            .IsRequired();
        
        builder.Ignore(x => x.ValidationResult);

        builder.ToTable("Reg_Regiao", "Cadastro");
    }
}
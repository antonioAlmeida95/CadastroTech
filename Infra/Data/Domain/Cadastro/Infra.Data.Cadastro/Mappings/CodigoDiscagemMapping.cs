using Domain.Cadastro;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Data.Cadastro.Mappings;

public class CodigoDiscagemMapping : IEntityTypeConfiguration<CodigoDiscagem>
{
    public void Configure(EntityTypeBuilder<CodigoDiscagem> builder)
    {
        builder.Property(x => x.Id)
            .HasColumnName("Cod_CodigoDiscagemId");
        
        builder.Property(x => x.Ddd)
            .HasColumnName("Cod_Ddd")
            .HasMaxLength(3)
            .IsRequired();

        builder.Property(x => x.RegiaoId)
            .HasColumnName("Reg_RegiaoId")
            .IsRequired();

        builder.HasOne(x => x.Regiao)
            .WithMany(x => x.CodigosDiscagem)
            .HasForeignKey(x => x.RegiaoId);
        
        builder.Ignore(x => x.ValidationResult);

        builder.ToTable("Cod_CodigoDiscagem", "Cadastro");
    }
}
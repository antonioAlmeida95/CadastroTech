using Domain.Cadastro;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Data.Cadastro.Mappings;

public class ContatoMapping : IEntityTypeConfiguration<Contato>
{
    public void Configure(EntityTypeBuilder<Contato> builder)
    {
        builder.Property(x => x.Id)
            .HasColumnName("Con_ContatoId");

        builder.Property(x => x.Nome)
            .HasColumnName("Con_Nome")
            .IsRequired();

        builder.Property(x => x.Telefone)
            .HasColumnName("Con_Telefone")
            .IsRequired();

        builder.Property(x => x.Email)
            .HasColumnName("Con_Email")
            .HasMaxLength(50);

        builder.Property(x => x.CodigoDiscagemId)
            .HasColumnName("Cod_CodigoDiscagemId")
            .IsRequired();

        builder.HasOne(x => x.CodigoDiscagem)
            .WithMany(x => x.Contatos)
            .HasForeignKey(x => x.CodigoDiscagemId);
        
        builder.Ignore(x => x.ValidationResult);

        builder.ToTable("Con_Contato", "Cadastro");
    }
}
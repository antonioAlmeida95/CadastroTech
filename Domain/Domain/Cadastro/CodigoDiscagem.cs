using FluentValidation;

namespace Domain.Cadastro;

public class CodigoDiscagem(int ddd, Guid regiaoId) : EntidadeBase<CodigoDiscagem>
{
    public int Ddd { get; } = ddd;
    public Guid RegiaoId { get; } = regiaoId;
    public virtual Regiao Regiao { get; }

    public virtual ICollection<Contato> Contatos { get; set; }

    public override bool ValidarEntidade()
    {
        RuleFor(x => x.Ddd)
            .Must(s => s <= 0)
            .WithMessage("Valor inválido para o campo do DDD");

        RuleFor(x => x.RegiaoId)
            .NotEmpty()
            .WithMessage("O identificador da Região é necessário ser informado.");
        
        ValidationResult = Validate(this);

        return ValidationResult.IsValid;
    }
}
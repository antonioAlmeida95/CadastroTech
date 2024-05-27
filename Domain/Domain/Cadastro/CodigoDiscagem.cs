using FluentValidation;

namespace Domain.Cadastro;

public class CodigoDiscagem: EntidadeBase<CodigoDiscagem>
{
    public int Ddd { get; }
    public Guid RegiaoId { get; }
    public virtual Regiao Regiao { get; private set;  }

    public virtual ICollection<Contato> Contatos { get; init; }

    public void AlterarRegiao(Regiao regiao) => Regiao = regiao;

    public CodigoDiscagem()
    {
        Contatos = new List<Contato>();
    }
    
    public CodigoDiscagem(int ddd, Guid regiaoId) : this()
    {
        Ddd = ddd;
        RegiaoId = regiaoId;
    }

    public CodigoDiscagem(Guid? id, int ddd, Guid regiaoId) : this(ddd, regiaoId)
    {
        Id = id ?? Guid.NewGuid();
    }

    public override bool ValidarEntidade()
    {
        RuleFor(x => x.Ddd)
            .Must(s => s > 0)
            .WithMessage("Valor inválido para o campo do DDD");

        RuleFor(x => x.RegiaoId)
            .NotEmpty()
            .WithMessage("O identificador da Região é necessário");
        
        ValidationResult = Validate(this);

        return ValidationResult.IsValid;
    }
}
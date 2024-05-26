using FluentValidation;

namespace Domain.Cadastro;

public class Regiao : EntidadeBase<Regiao>
{
    public string Nome { get; }
    public string Sigla { get; }
    
    public virtual ICollection<CodigoDiscagem> CodigosDiscagem { get; init; }
    
    public Regiao(string nome, string sigla)
    {
        Nome = nome;
        Sigla = sigla;
    }

    public Regiao(Guid? id, string nome, string sigla) : this(nome, sigla)
    {
        Id = id ?? Guid.NewGuid();
    }

    public Regiao() { }
    
    public override bool ValidarEntidade()
    {
        RuleFor(x => x.Nome)
            .NotEmpty()
            .WithMessage("O Nome é um campo obrigatório");
        
        RuleFor(x => x.Sigla)
            .NotEmpty()
            .WithMessage("O Sigla é um campo obrigatório");
        
        ValidationResult = Validate(this);

        return ValidationResult.IsValid;
    }
}
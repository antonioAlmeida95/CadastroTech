using FluentValidation;

namespace Domain;

public class Regiao(string nome, string sigla) : EntidadeBase<Regiao>
{
    public string Nome { get; } = nome;
    public string Sigla { get; } = sigla;

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
using FluentValidation;

namespace Domain.Cadastro;

public class Contato(string nome, string telefone, string email) : EntidadeBase<Contato>
{
    public string Nome { get; } = nome;
    public string Telefone { get; } = telefone;
    public string Email { get; } = email;

    public Guid CodigoDiscagemId { get; private set; }
    public virtual CodigoDiscagem CodigoDiscagem { get; private set; }

    public void AlterarCodigoDiscagemId(Guid codigoDiscagemId) => CodigoDiscagemId = codigoDiscagemId;

    public override bool ValidarEntidade()
    {
        RuleFor(x => x.Nome)
            .NotEmpty()
            .WithMessage("O Nome é um campo obrigatório");
        
        RuleFor(x => x.Telefone)
            .NotEmpty()
            .WithMessage("O Telefone é obrigatório");
        
        RuleFor(x => x.Email)
            .NotEmpty()
            .WithMessage("O Email é obrigatório");

        RuleFor(x => x.Email)
            .EmailAddress()
            .WithMessage("O Email está inválido");
        
        ValidationResult = Validate(this);

        return ValidationResult.IsValid;
    }
}
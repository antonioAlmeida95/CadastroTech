using FluentValidation;

namespace Domain.Cadastro;

public class Contato : EntidadeBase<Contato>
{
    public string Nome { get; private set; }
    public string Telefone { get; private set; }
    public string Email { get; private set;  }

    public Guid CodigoDiscagemId { get; private set; }
    public virtual CodigoDiscagem CodigoDiscagem { get; private set; }

    public void AlterarCodigoDiscagemId(Guid codigoDiscagemId) => CodigoDiscagemId = codigoDiscagemId;
    public void AlterarCodigoDiscagem(CodigoDiscagem codigoDiscagem) => CodigoDiscagem = codigoDiscagem;
    public void AlterarNome(string nome) => Nome = nome;
    public void AlterarTelefone(string telefone) => Telefone = telefone;
    public void AlterarEmail(string email) => Email = email;

    public Contato() { }

    public Contato(string nome, string telefone, string email, Guid codigoDiscagemId, Guid? id = null)
        : this(nome, telefone, email, codigoDiscagemId)
    {
        Id = id ?? Guid.NewGuid();
    }
    
    public Contato(string nome, string telefone, string email, Guid codigoDiscagemId)
    {
        Nome = nome;
        Telefone = telefone;
        Email = email;
        CodigoDiscagemId = codigoDiscagemId;
    }

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
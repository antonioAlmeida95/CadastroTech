using System;
using System.ComponentModel.DataAnnotations;

namespace Application.Cadastro.ViewModels;

public class ContatoBaseViewModel
{
    [Required(ErrorMessage = "Nome é um campo Obrigatório.")]
    [MaxLength(60)]
    [MinLength(2)]
    public string Nome { get; set; }
    
    [Required(ErrorMessage = "Telefone é um campo Obrigatório.")]
    [MaxLength(10)]
    [MinLength(9)]
    public string Telefone { get; set; }
    
    [Required(ErrorMessage = "Email é um campo Obrigatório.")]
    [EmailAddress]
    public string Email { get; set; }
    
    [Required(ErrorMessage = "Identificador do Código de Discagem é um campo Obrigatório.")]
    public Guid CodigoDiscagemId { get; set; }
}
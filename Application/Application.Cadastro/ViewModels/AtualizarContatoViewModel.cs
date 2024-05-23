using System;
using System.ComponentModel.DataAnnotations;

namespace Application.Cadastro.ViewModels;

public class AtualizarContatoViewModel : ContatoBaseViewModel
{
    [Required(ErrorMessage = "Identificador do Contato é um campo Obrigatório.")]
    public Guid ContatoId { get; set; }
}
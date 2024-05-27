using System;

namespace Application.Cadastro.ViewModels;

public class ContatoViewModel
{
    public Guid ContatoId { get; set; }
    public string Nome { get; set; }
    public string Telefone { get; set; }
    public string Email { get; set; }
    public CodigoDiscagemViewModel CodigoDiscagem { get; set; }
}
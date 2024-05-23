using System;

namespace Application.Cadastro.ViewModels;

public class ContatoFiltroViewModel
{
    public Guid[] ContatosId { get; set; }
    public string Nome { get; set; }
    public string Email { get; set; }
    public string Telefone { get; set; }
    public Guid? RegiaoId { get; set; }
    public int? Ddd { get; set; }
}
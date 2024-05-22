using System;

namespace Application.Cadastro.ViewModels;

public class RegiaoFiltroViewModel
{
    public Guid[] RegiaoIds { get; set; }
    public string Nome { get; set; }
    public string Sigla { get; set; }
}
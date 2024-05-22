using System;

namespace Application.Cadastro.ViewModels;

public class CodigoDiscagemViewModel
{
    public Guid CodigoDiscagemId { get; set; }
    public int Ddd { get; set; }
    public RegiaoViewModel Regiao { get; set; }
}
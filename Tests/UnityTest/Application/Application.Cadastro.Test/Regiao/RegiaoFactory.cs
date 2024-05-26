using System;
using Application.Cadastro.ViewModels;
using RegiaoDomain = Domain.Cadastro.Regiao;

namespace Application.Cadastro.Test.Regiao;

public static class RegiaoFactory
{
    public static RegiaoDomain GerarRegiao(Guid? id = null, string nome = "Nordeste", string sigla = "NE")
    {
        return new RegiaoDomain(id ?? Guid.NewGuid(), nome, sigla);
    }

    public static RegiaoFiltroViewModel GerarRegiaoFiltroViewModel(Guid[] regioesIds = null, string nome = null,
        string sigla = null)
    {
        return new RegiaoFiltroViewModel
        {
            Nome = nome,
            RegiaoIds = regioesIds ?? [],
            Sigla = sigla
        };
    }
}
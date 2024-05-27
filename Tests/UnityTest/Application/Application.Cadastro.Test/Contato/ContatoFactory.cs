using System;
using Application.Cadastro.ViewModels;
using Domain.Cadastro;
using ContatoDomain = Domain.Cadastro.Contato;
using RegiaoDomain = Domain.Cadastro.Regiao;

namespace Application.Cadastro.Test.Contato;

public static class ContatoFactory
{
    public static ContatoDomain GerarContato(string nome = "Lucas", string telefone = "799898989", 
        string email = "teste@mail.com", Guid? codigoDiscagemId = null, Guid? id = null,
        CodigoDiscagem codigoDiscagem = null)
    {
        var contato = new ContatoDomain(nome, telefone, email, codigoDiscagemId ?? Guid.NewGuid(),
            id ?? Guid.NewGuid());
        
        if(codigoDiscagem != null) contato.AlterarCodigoDiscagem(codigoDiscagem);
        
        return contato;
    }

    public static CodigoDiscagem GerarCodigoDiscagem(Guid? id = null, int? ddd = null, Guid? regiaoId = null,
        RegiaoDomain regiao = null)
    {
        var codigoDiscagem = new CodigoDiscagem(id: id, ddd ?? 0, regiaoId ?? Guid.NewGuid());
        
        if(regiao != null) codigoDiscagem.AlterarRegiao(regiao);

        return codigoDiscagem;
    }
    
    public static RegiaoDomain GerarRegiao(Guid? id = null, string nome = "Nordeste", string sigla = "NE")
    {
        return new RegiaoDomain(id ?? Guid.NewGuid(), nome, sigla);
    }

    public static CadastrarContatoViewModel GerarCadastrarContatoViewModel(string nome = "Lucas",
        string telefone = "799898989", string email = "teste@mail.com", Guid? codigoDiscagemId = null)
    {
        return new CadastrarContatoViewModel
        {
            Nome = nome,
            Email = email,
            Telefone = telefone,
            CodigoDiscagemId = codigoDiscagemId ?? Guid.NewGuid()
        };
    }

    public static AtualizarContatoViewModel GerarAtualizarContatoViewModel(Guid? contatoId = null, string nome = "Lucas",
        string telefone = "799898989", string email = "teste@mail.com", Guid? codigoDiscagemId = null)
    {
        return new AtualizarContatoViewModel
        {
            ContatoId = contatoId ?? Guid.NewGuid(),
            Nome = nome,
            Email = email,
            Telefone = telefone,
            CodigoDiscagemId = codigoDiscagemId ?? Guid.NewGuid()
        };
    }

    public static ContatoFiltroViewModel GerarContatoFiltroViewModel(Guid[] contatosId = null, 
        string telefone = null, string email = null, string nome = null, Guid? regiaoId = null, int? ddd = null )
    {
        return new ContatoFiltroViewModel
        {
            ContatosId = contatosId,
            Telefone = telefone,
            Email = email,
            Nome = nome,
            RegiaoId = regiaoId,
            Ddd = ddd
        };
    }

    public static CodigoDiscagemFiltroViewModel GerarCodigoDiscagemFiltroViewModel(Guid? codigoDiscagemId = null,
        int ddd = 0, Guid? regiaoId = null)
    {
        return new CodigoDiscagemFiltroViewModel
        {
            CodigoDiscagemId = codigoDiscagemId,
            Ddd = ddd,
            RegiaoId = regiaoId
        };
    }
}
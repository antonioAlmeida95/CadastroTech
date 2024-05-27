using System;
using System.Collections.Generic;
using Domain.Cadastro;
using ContatoDomain = Domain.Cadastro.Contato;

namespace Application.Cadastro.Test.Contato;

public partial class ContatoAppServiceTest
{
    public static IEnumerable<object[]> ParamsContatoDadosInvalidos()
    {
        yield return
        [
            ContatoFactory.GerarCadastrarContatoViewModel(nome: string.Empty, telefone: string.Empty,
                email: string.Empty)
        ];
        
        yield return
        [
            ContatoFactory.GerarCadastrarContatoViewModel(nome: string.Empty)
        ];
        
        yield return
        [
            ContatoFactory.GerarCadastrarContatoViewModel(telefone: string.Empty)
        ];
        
        yield return
        [
            ContatoFactory.GerarCadastrarContatoViewModel(email: string.Empty)
        ];
        
        yield return
        [
            ContatoFactory.GerarCadastrarContatoViewModel(email: "teste.mail.com.br")
        ];
    }
    
    public static IEnumerable<object[]> ParamsAtualizarContatoDadosInvalidos()
    {
        var contatoId = Guid.NewGuid();
        var contatos = new List<ContatoDomain>
        {
            ContatoFactory.GerarContato(),
            ContatoFactory.GerarContato(),
            ContatoFactory.GerarContato(id: contatoId)
        };
        
        yield return
        [
            contatos,
            ContatoFactory.GerarAtualizarContatoViewModel(contatoId: contatoId, nome: string.Empty,
                telefone: "9898889998", email: "antonio@mail.com", codigoDiscagemId: Guid.NewGuid())
        ];
        
        yield return
        [
            contatos,
            ContatoFactory.GerarAtualizarContatoViewModel(contatoId: contatoId, nome: "Antonio L",
                telefone: string.Empty, email: "antonio@mail.com", codigoDiscagemId: Guid.NewGuid())
        ];
        
        yield return
        [
            contatos,
            ContatoFactory.GerarAtualizarContatoViewModel(contatoId: contatoId, nome: "Antonio L",
                telefone: "9898889998", email: string.Empty, codigoDiscagemId: Guid.NewGuid())
        ];
        
        yield return
        [
            contatos,
            ContatoFactory.GerarAtualizarContatoViewModel(contatoId: contatoId, nome: "Antonio L",
                telefone: "9898889998", email: "teste.mail.com.br", codigoDiscagemId: Guid.NewGuid())
        ];
    }

    public static IEnumerable<object[]> ParamsContatosFiltros()
    {
        var contatoId = Guid.NewGuid();
        var nome = "Ezio";
        var telefone = "9989898899";
        var email = "teste@mail.com.br";
        
        var regiaoId = Guid.NewGuid();
        var regiao = ContatoFactory.GerarRegiao(regiaoId, "Norte", "N");
        
        var ddd = 79;
        var codigoDiscagem = ContatoFactory.GerarCodigoDiscagem(ddd: ddd, regiaoId: regiaoId, regiao: regiao);
        
        //Contato 1
        var contato1 = ContatoFactory.GerarContato(nome, telefone, email, Guid.NewGuid(), contatoId, codigoDiscagem);
        
        //Contato 2
        var contato2 = ContatoFactory.GerarContato(nome: nome, codigoDiscagem: codigoDiscagem);
        
        //Contato 3
        var contatoId2 = Guid.NewGuid(); 
        var contato3 = ContatoFactory.GerarContato(id: contatoId2, codigoDiscagem: codigoDiscagem);
        
        //Contato 4
        var regiaoId2 = Guid.NewGuid();
        var regiao2 = ContatoFactory.GerarRegiao(regiaoId2, "Sul", "S");
        
        var ddd2 = 78;
        var codigoDiscagem2 = ContatoFactory.GerarCodigoDiscagem(ddd: ddd2, regiaoId: regiaoId2, regiao: regiao2);
        var contato4 = ContatoFactory.GerarContato(nome, telefone, email, codigoDiscagem: codigoDiscagem2);
        
        yield return
        [
            new List<ContatoDomain> { contato1, contato2, contato3, contato4 },
            ContatoFactory.GerarContatoFiltroViewModel([contatoId, contatoId2]),
            new List<ContatoDomain> { contato1, contato3 },
            2
        ];
        
        yield return
        [
            new List<ContatoDomain> { contato1, contato2, contato3, contato4 },
            ContatoFactory.GerarContatoFiltroViewModel([contatoId]),
            new List<ContatoDomain> { contato1 },
            1
        ];
        
        yield return
        [
            new List<ContatoDomain> { contato1, contato2, contato3, contato4 },
            ContatoFactory.GerarContatoFiltroViewModel(nome: nome),
            new List<ContatoDomain> { contato1, contato2, contato4 },
            3
        ];
        
        yield return
        [
            new List<ContatoDomain> { contato1, contato2, contato3, contato4 },
            ContatoFactory.GerarContatoFiltroViewModel(email: email),
            new List<ContatoDomain> { contato1, contato4 },
            2
        ];
        
        yield return
        [
            new List<ContatoDomain> { contato1, contato2, contato3, contato4 },
            ContatoFactory.GerarContatoFiltroViewModel(telefone: telefone),
            new List<ContatoDomain> { contato1, contato4 },
            2
        ];
        
        yield return
        [
            new List<ContatoDomain> { contato1, contato2, contato3, contato4 },
            ContatoFactory.GerarContatoFiltroViewModel(regiaoId: regiaoId),
            new List<ContatoDomain> { contato1, contato2, contato3 },
            3
        ];
        
        yield return
        [
            new List<ContatoDomain> { contato1, contato2, contato3, contato4 },
            ContatoFactory.GerarContatoFiltroViewModel(ddd: ddd2),
            new List<ContatoDomain> { contato4 },
            1
        ];
    }

    public static IEnumerable<object[]> ParamsCodigoDiscagemFiltros()
    {
        var codigoDiscagemId = Guid.NewGuid();
        var ddd = 79;
        var regiaoId = Guid.NewGuid();

        //CodigoDiscagem 1
        var ddd1 = 67;
        var codigoDiscagem1 = ContatoFactory.GerarCodigoDiscagem(codigoDiscagemId, ddd1, regiaoId);
        
        //CodigoDiscagem 2
        var codigoDiscagem2 = ContatoFactory.GerarCodigoDiscagem( ddd: ddd, regiaoId: regiaoId);
        
        //CodigoDiscagem 3
        var codigoDiscagem3= ContatoFactory.GerarCodigoDiscagem(ddd: ddd, regiaoId: regiaoId);
        
        //CodigoDiscagem 4
        var regiaoId2 = Guid.NewGuid();
        var ddd2 = 86;
        var codigoDiscagem4 = ContatoFactory.GerarCodigoDiscagem(ddd: ddd2, regiaoId: regiaoId2);
        
        yield return
        [
           new List<CodigoDiscagem> {codigoDiscagem1, codigoDiscagem3, codigoDiscagem2, codigoDiscagem4 },
           ContatoFactory.GerarCodigoDiscagemFiltroViewModel(codigoDiscagemId: codigoDiscagemId),
           new List<CodigoDiscagem> { codigoDiscagem1 },
           1
        ];
        
        // yield return
        // [
        //     new List<CodigoDiscagem> {codigoDiscagem1, codigoDiscagem3, codigoDiscagem2, codigoDiscagem4 },
        //     ContatoFactory.GerarCodigoDiscagemFiltroViewModel(regiaoId: regiaoId),
        //     new List<CodigoDiscagem> { codigoDiscagem1, codigoDiscagem2, codigoDiscagem3 },
        //     3
        // ];
        //
        // yield return
        // [
        //     new List<CodigoDiscagem> {codigoDiscagem1, codigoDiscagem3, codigoDiscagem2, codigoDiscagem4 },
        //     ContatoFactory.GerarCodigoDiscagemFiltroViewModel(ddd: ddd),
        //     new List<CodigoDiscagem> { codigoDiscagem2, codigoDiscagem3 },
        //     2
        // ];
    }
}
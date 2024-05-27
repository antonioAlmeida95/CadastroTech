using System;
using System.Collections.Generic;

namespace Domain.Cadastro.Test;

public class RegiaoTest
{
    [Fact(DisplayName = "Criar Regiao - Sucesso")]
    public void Contato_CriaRegiao_Sucesso()
    {
        //Arrange
        var id = Guid.NewGuid();
        const string nome = "Nordeste";
        const string sigla = "NE";
       
        //Act
        var regiao = new Regiao(id, nome, sigla);
        
        //Assert
        Assert.True(regiao.ValidarEntidade());
        Assert.Empty(regiao.CodigosDiscagem);
        Assert.Equal(id, regiao.Id);
        Assert.Equal(nome, regiao.Nome);
        Assert.Equal(sigla, regiao.Sigla);
    }
    
    [Fact(DisplayName = "Criar Regiao - Falha")]
    public void Contato_CriaRegiao_Falha()
    {
        //Arrange
        //Act
        var regiao = new Regiao();
        
        //Assert
        Assert.False(regiao.ValidarEntidade());
    }
    
    [Theory(DisplayName = "Criar Regiao com campos invalidos - Falha")]
    [MemberData(nameof(ParamsInvalidosContato))]
    public void Contato_CriaRegiaoCamposInvalidos_Falha(Regiao regiao, string mensagem)
    {
        //Arrange
        //Act
        
        //Assert
        Assert.False(regiao.ValidarEntidade());
        Assert.Contains(regiao.ValidationResult.Errors, m => m.ErrorMessage.Equals(mensagem));
    }
    
    public static IEnumerable<object[]> ParamsInvalidosContato()
    {
        var id = Guid.NewGuid();
        const string nome = "Nordeste";
        const string sigla = "NE";
        
        yield return
        [
            new Regiao(id, string.Empty, sigla),
            "O Nome é um campo obrigatório"
        ];
        
        yield return
        [
            new Regiao(id, nome, string.Empty),
            "A Sigla é um campo obrigatório"
        ];
    }
}
using System;
using System.Collections.Generic;

namespace Domain.Cadastro.Test;

public class ContatoTest
{
    [Fact(DisplayName = "Criar Contato - Sucesso")]
    public void Contato_CriaContato_Sucesso()
    {
        //Arrange
        var id = Guid.NewGuid();
        const string nome = "Usuario";
        const string telefone = "989888998";
        const string email = "user@mail.com";
        var codigoDiscagemId = Guid.NewGuid();

        //Act
        var contato = new Contato(nome, telefone, email, codigoDiscagemId, id);
        
        //Assert
        Assert.True(contato.ValidarEntidade());
        Assert.Equal(id, contato.Id);
        Assert.Equal(nome, contato.Nome);
        Assert.Equal(telefone, contato.Telefone);
        Assert.Equal(email, contato.Email);
        Assert.Equal(codigoDiscagemId, contato.CodigoDiscagemId);
    }
    
    [Fact(DisplayName = "Criar Contato - Falha")]
    public void Contato_CriaContato_Falha()
    {
        //Arrange
        //Act
        var contato = new Contato();
        
        //Assert
        Assert.False(contato.ValidarEntidade());
    }
    
    [Theory(DisplayName = "Criar Contato com campos invalidos - Falha")]
    [MemberData(nameof(ParamsInvalidosContato))]
    public void Contato_CriaContatoCamposInvalidos_Falha(Contato contato, string mensagem)
    {
        //Arrange
        //Act
        
        //Assert
        Assert.False(contato.ValidarEntidade());
        Assert.Contains(contato.ValidationResult.Errors, m => m.ErrorMessage.Equals(mensagem));
    }
    
    public static IEnumerable<object[]> ParamsInvalidosContato()
    {
        var id = Guid.NewGuid();
        const string nome = "Usuario";
        const string telefone = "989888998";
        const string email = "user@mail.com";
        var codigoDiscagemId = Guid.NewGuid();
        
        yield return
        [
            new Contato(string.Empty, telefone, email, codigoDiscagemId, id),
            "O Nome é um campo obrigatório"
        ];
        
        yield return
        [
            new Contato(nome, string.Empty, email, codigoDiscagemId, id),
            "O Telefone é obrigatório"
        ];
        
        yield return
        [
            new Contato(nome, telefone, string.Empty, codigoDiscagemId, id),
            "O Email é obrigatório"
        ];
        
        yield return
        [
            new Contato(nome, telefone, "user.mail.com", codigoDiscagemId, id),
            "O Email está inválido"
        ];
    }
}
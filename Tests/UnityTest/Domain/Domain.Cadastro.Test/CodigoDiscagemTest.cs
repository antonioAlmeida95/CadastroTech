using System;
using System.Collections.Generic;

namespace Domain.Cadastro.Test;

public class CodigoDiscagemTest
{
    [Fact(DisplayName = "Criar CodigoDiscagem - Sucesso")]
    public void CodigoDiscagem_CriaCodigoDiscagem_Sucesso()
    {
        //Arrange
        var id = Guid.NewGuid();
        var ddd = 79;
        var regiaoId = Guid.NewGuid();

        //Act
        var codigoDiscagem = new CodigoDiscagem(id, ddd, regiaoId);
        
        //Assert
        Assert.True(codigoDiscagem.ValidarEntidade());
        Assert.Empty(codigoDiscagem.Contatos);
        Assert.Equal(id, codigoDiscagem.Id);
        Assert.Equal(ddd, codigoDiscagem.Ddd);
        Assert.Equal(regiaoId, codigoDiscagem.RegiaoId);
    }
    
    [Fact(DisplayName = "Criar CodigoDiscagem - Falha")]
    public void Contato_CriaCodigoDiscagem_Falha()
    {
        //Arrange
        //Act
        var contato = new CodigoDiscagem();
        
        //Assert
        Assert.False(contato.ValidarEntidade());
    }
    
    [Theory(DisplayName = "Criar CodigoDiscagem com campos invalidos - Falha")]
    [MemberData(nameof(ParamsInvalidosCodigoDiscagem))]
    public void Contato_CriaCodigoDiscagemCamposInvalidos_Falha(CodigoDiscagem codigoDiscagem, string mensagem)
    {
        //Arrange
        //Act
        
        //Assert
        Assert.False(codigoDiscagem.ValidarEntidade());
        Assert.Contains(codigoDiscagem.ValidationResult.Errors, m => m.ErrorMessage.Equals(mensagem));
    }
    
    public static IEnumerable<object[]> ParamsInvalidosCodigoDiscagem()
    {
        var id = Guid.NewGuid();
        var ddd = 79;
        var regiaoId = Guid.NewGuid();
        
        yield return
        [
            new CodigoDiscagem(id, 0, regiaoId),
            "Valor inválido para o campo do DDD"
        ];
        
        yield return
        [
            new CodigoDiscagem(id, ddd, Guid.Empty),
            "O identificador da Região é necessário"
        ];
    }
}
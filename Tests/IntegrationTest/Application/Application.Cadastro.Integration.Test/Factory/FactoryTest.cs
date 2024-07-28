using Application.Cadastro.ViewModels;
using System;

namespace Application.Cadastro.Integration.Test.Factory;

public static class FactoryTest
{
   public static CadastrarContatoViewModel GerarCadastrarContatoViewModel(string nome = null, string telefone = null,
      string email = null, Guid? codigoDiscagemId = null)
   {
      return new CadastrarContatoViewModel
      {
         Nome = nome ?? "Antonio Lucas",
         Telefone = telefone ?? "9989899888",
         Email = email ?? "test@gmail.com",
         CodigoDiscagemId = codigoDiscagemId ?? Guid.Parse("51fe35ef-ee56-4b7d-96d7-74c1c86a8c0f")
      };
   }
}
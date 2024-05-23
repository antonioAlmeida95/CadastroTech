using System;
using Application.Cadastro.ViewModels;
using AutoMapper;
using Domain.Cadastro;

namespace Application.Cadastro.AutoMapper;

public class ViewModelToDomainMappingProfile : Profile
{
    public ViewModelToDomainMappingProfile()
    {
        CreateMap<CadastrarContatoViewModel, Contato>()
            .ConstructUsing((c) => new Contato(c.Nome, c.Telefone, c.Email, c.CodigoDiscagemId, Guid.NewGuid()));
    }
}
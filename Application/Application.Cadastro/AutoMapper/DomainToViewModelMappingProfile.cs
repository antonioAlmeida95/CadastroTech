using Application.Cadastro.ViewModels;
using AutoMapper;
using Domain.Cadastro;

namespace Application.Cadastro.AutoMapper;

public class DomainToViewModelMappingProfile : Profile
{
    public DomainToViewModelMappingProfile()
    {
        //Regiao
        CreateMap<Regiao, RegiaoViewModel>()
            .ForMember(x => x.RegiaoId, opt => opt.MapFrom(src => src.Id));
        
        //CodigoDiscagem
        CreateMap<CodigoDiscagem, CodigoDiscagemViewModel>()
            .ForMember(x => x.CodigoDiscagemId, opt => opt.MapFrom(src => src.Id));
        
        //Contato
        CreateMap<Contato, ContatoViewModel>()
            .ForMember(x => x.ContatoId, opt => opt.MapFrom(src => src.Id));
    }
}
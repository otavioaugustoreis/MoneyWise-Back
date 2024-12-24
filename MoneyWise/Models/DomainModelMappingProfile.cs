using AutoMapper;
using MoneyWise.Data.Entities;

namespace MoneyWise.Models
{

    //Essa classe é feita para configurar as classes que serão utilizadar pelo Mapper para prover o uso do DTO 
    public class DomainModelMappingProfile : Profile 
    {
        public DomainModelMappingProfile() 
        {
            //Mapeando pedido e informando que iremos carregar as informações do usuário tbm
            CreateMap<PedidoEntity, PedidoModel>()
           .ForMember(dest => dest.Usuario, opt => opt.MapFrom(src => src.usuarioEntity));

            //Mapeando  AutoMapper
            CreateMap<UsuarioEntity, UsuarioModel>().ReverseMap();
        }
    }
}

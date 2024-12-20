using AutoMapper;
using MoneyWise.Data.Entities;

namespace MoneyWise.Models
{
    public class DomainModelMappingProfile : Profile 
    {
        public DomainModelMappingProfile() 
        {
            //Mapeando  AutoMapper
            CreateMap<UsuarioEntity, UsuarioModel>().ReverseMap();
        }
    }
}

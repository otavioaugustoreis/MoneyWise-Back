using AutoMapper;
using MoneyWise.Models;


namespace MoneyWise.Providers
{
    public static class AutoMapperStartup
    {
        //Classe feita para configurar o uso do AutoMapper
        public static IServiceCollection AddMapperStartup(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(DomainModelMappingProfile));

            return services;
        }
    }
}

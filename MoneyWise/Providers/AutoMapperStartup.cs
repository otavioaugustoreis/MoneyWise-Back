using AutoMapper;
using MoneyWise.Models;


namespace MoneyWise.Providers
{
    public static class AutoMapperStartup
    {
        public static IServiceCollection AddMapperStartup(this IServiceCollection services)
        {
            //services.AddAutoMapper(typeof(DomainModelMappingProfile));

            return services;
        }
    }
}

using MoneyWise.Data;
using MoneyWise.Domain.Services;
using MoneyWise.Repository.Interfaces;
using MoneyWise.Repository.Patterns;

namespace MoneyWise.Providers
{
    public static class ClassesStartup
    {
        public static IServiceCollection AddDIPScoppedClasse(this IServiceCollection services )
        {
            //Inicializando as classes com Scoped
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IUsuarioRepository, UsuarioService>();
            services.AddScoped<IPedidoRepository, PedidoService>();
            services.AddScoped<SeedingServiceData>();

            return services;
        }
        public static IServiceCollection AddDIPSingletonClasse(this IServiceCollection services)
        {
            return services;
        }

        public static IServiceCollection AddDIPTransientClasse(this IServiceCollection services)
        {
            return services;
        }
    }
}

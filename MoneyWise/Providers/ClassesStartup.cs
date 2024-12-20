using MoneyWise.Domain.Services;
using MoneyWise.Repository.Interfaces;
using MoneyWise.Repository.Patterns;

namespace MoneyWise.Providers
{
    public static class ClassesStartup
    {
        public static IServiceCollection AddDIPScoppedClasse(this IServiceCollection services )
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            services.AddScoped<IUsuarioRepository, UsuarioService>();
            services.AddScoped<IPedidoRepository, PedidoService>();


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

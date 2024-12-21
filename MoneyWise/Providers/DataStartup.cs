using Microsoft.EntityFrameworkCore;
using MoneyWise.Data.Context;

namespace MoneyWise.Providers
{
    public  static class DataStartup
    {

        public static IServiceCollection AddConectionBD(this IServiceCollection services, string mySqlConnection)
        {
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(mySqlConnection, sqlOptions =>
                {
                    sqlOptions.EnableRetryOnFailure(); // Tenta reconexão em caso de falha
                });
            });

            return services;
        }
    }
}

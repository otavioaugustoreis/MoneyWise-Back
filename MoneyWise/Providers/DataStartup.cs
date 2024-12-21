using Microsoft.EntityFrameworkCore;
using MoneyWise.Data.Context;

namespace MoneyWise.Providers
{
    public  static class DataStartup
    {

        public static IServiceCollection AddConectionBD(this IServiceCollection services, IConfiguration configuration)
        {
            string dbPassWord = Environment.GetEnvironmentVariable("DATABASE");

            string mySqlConnection = configuration.GetConnectionString("DefaultConnection").Replace("%DATABASE%", dbPassWord);


            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(mySqlConnection, sqlOptions =>
                {
                    
                    sqlOptions.EnableRetryOnFailure(); // Tenta reconexão em caso de falha
                    sqlOptions.MigrationsAssembly("MoneyWise.Data");
                });
            });


            return services;
        }
    }
}

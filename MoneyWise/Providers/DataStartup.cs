using Microsoft.EntityFrameworkCore;
using MoneyWise.Data.Context;

namespace MoneyWise.Providers
{
    public  static class DataStartup
    {

        public static IServiceCollection AddConectionBD(this IServiceCollection services, IConfiguration configuration)
        {
            //Pegando o valor da variável de ambiente
            string dbPassWord = Environment.GetEnvironmentVariable("DATABASE");

            //Pegando a conexão do appsettings.json e substituidndo o acesso pelo valor da variável de ambiente.
            string mySqlConnection = configuration.GetConnectionString("DefaultConnection")
                                                  .Replace("%DATABASE%", dbPassWord);

            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(mySqlConnection, sqlOptions =>
                {

                    // Tenta  com o banco reconexão em caso de falha
                    sqlOptions.EnableRetryOnFailure();
                    //Defino em qual Assembly está o EntityFrameWork, no caso está no 4 - Data
                    sqlOptions.MigrationsAssembly("MoneyWise.Data");
                });
            });

            return services;
        }
    }
}

using System.Text.Json.Serialization;

namespace MoneyWise.Providers
{
    public static class JsonStartup
    {
        //Ignorando referência ciclica
        public static object AddCofigurationJson(this IServiceCollection services)
        {
            services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
            }).AddNewtonsoftJson((
            //Configurando o NewTonSoftJso. Essa linha define que as propriedades dos objetos serializados e desserializados devem seguir o padrão camelCase.
            options =>
            {
                options.SerializerSettings.ContractResolver =
                    new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver();
            }));

            return services;
        }
    }
}


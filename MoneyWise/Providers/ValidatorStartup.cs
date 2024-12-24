using FluentValidation;
using FluentValidation.AspNetCore;
using MoneyWise.Models;
using MoneyWise.Validators;

namespace MoneyWise.Providers
{
    public static class ValidatorStartup
    {
        public static IServiceCollection AddValidator(this IServiceCollection services)
        {
            //Inicializando o Validator
            services.AddFluentValidationAutoValidation();
            services.AddValidatorsFromAssemblyContaining<PedidoModelValidator>();

            return services;
        }
    }
}

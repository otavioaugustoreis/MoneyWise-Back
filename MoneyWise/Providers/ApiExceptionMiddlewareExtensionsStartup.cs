using Microsoft.AspNetCore.Diagnostics;
using MoneyWise.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MoneyWise.Providers
{
    public static class ApiExceptionMiddlewareExtensionsStartup
    {
        public static void ConfigureExceptionHandler(this IApplicationBuilder app )//ILogger logger
        {
            //Configurando o middleware de tratamento de exceções 

            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    //Definindo status code caso haja uma exceção
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    //Resposta no formato Json
                    context.Response.ContentType = "application/json";

                    //Feature de manipulação de exceções
                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();

                    //Verificando se uma exceção ocorreu
                    if (contextFeature != null)
                    {

                        // Resposta de erro para o cliente
                        await context.Response.WriteAsync(new ErrorDetails()
                        {
                            StatusCode = context.Response.StatusCode,
                            Message = contextFeature.Error.Message,
                            Trace = contextFeature.Error.StackTrace
                        }.ToString());
                    }
                });
            });
        }
    }
}

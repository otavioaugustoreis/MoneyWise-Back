using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MoneyWise.Domain.Exceptions
{

    //Esta classe foi criada para detalhar os erros registrados pela exceção
    public class ErrorDetails
    {

        //Status do erro
        public int StatusCode { get; set; }

        //Mensagem do erro
        public string? Message { get; set; }
        //Rastreamento de pilha
        public string? Trace { get; set; }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}

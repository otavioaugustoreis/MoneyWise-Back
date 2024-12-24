using MoneyWise.Repository.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyWise.Domain.Filters
{
    public class UsuarioFilter : QueryStringParameters 
    {
        public int? NrIdade { get; set; }
        public string? NrIdadeCriterio { get; set; }
    }
}

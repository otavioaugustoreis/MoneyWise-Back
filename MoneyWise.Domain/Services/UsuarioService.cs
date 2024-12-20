using MoneyWise.Data.Context;
using MoneyWise.Data.Entities;
using MoneyWise.Repository.Interfaces;
using MoneyWise.Repository.Patterns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyWise.Domain.Services
{
    public class UsuarioService : Repository<UsuarioEntity>, IUsuarioRepository
    {
        public UsuarioService(AppDbContext context) : base(context)
        {
        }
    }
}


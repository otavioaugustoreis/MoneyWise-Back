using Microsoft.EntityFrameworkCore;
using MoneyWise.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MoneyWise.Repository.Patterns
{
    public class Repository<T> : IRepository<T> where T : class 
    {
        protected readonly AppDbContext _context;

        public Repository(AppDbContext context)
        {
            _context = context;
        }

        public T Delete(T entidade)
        {
            _context.Set<T>().Remove(entidade);
            _context.SaveChanges();
            return entidade;
        }

        public IEnumerable<T> Get()
        {
            return _context.Set<T>().AsNoTracking().ToList();
        }

        public T? GetId(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().FirstOrDefault(predicate);
        }

        public T Post(T entidade)
        {
            _context.Set<T>().Add(entidade);
            _context.SaveChanges();
            return entidade;
        }

        public T Put(T entidade)
        {
            _context.Set<T>().Update(entidade);
            _context.SaveChanges();
            return entidade;
        }
    }
}

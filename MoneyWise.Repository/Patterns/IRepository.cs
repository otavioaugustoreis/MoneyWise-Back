using MoneyWise.Data.Entities;
using MoneyWise.Domain.Filters;
using MoneyWise.Repository.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MoneyWise.Repository.Patterns
{
    public interface IRepository<T>
    {
        public IEnumerable<T> Get();
        public T GetId(Expression<Func<T, bool>> predicate);
        public T Post(T entidade);
        public T Put(T entidade);
        public T Delete(T entidade);
    }
}

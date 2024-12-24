using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyWise.Repository.Patterns
{

    //Classe para realizar paginação
    public class PagedList<T> : List<T> where T : class
    {
        public PagedList()
        {
        }

        public PagedList(IEnumerable<T> collection) : base(collection)
        {
        }

        public PagedList(int capacity) : base(capacity)
        {
        }

        //Armazena o numero da página atual
        public int CurrentPage { get; private set; }

        //Total de paginas
        public int TotalPages { get; private set; }

        //Numero para serem exibidos na página
        public int PageSize { get; private set; }

        //numero total de elementos na fonte de dados 
        public int TotalCount { get; private set; }

        //Verifica se existe uma página anterior do que uma página atual
        public bool HasPrevius => CurrentPage > 1;
        //Se existe uma página seguinte a atual
        public bool HasNext => CurrentPage < TotalPages;

        public PagedList(List<T> items, int count, int pageNumber, int pageSize)
        {
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            PageSize = pageSize;
            TotalCount = count;
            CurrentPage = pageNumber;

            AddRange(items);
        }
        public static PagedList<T> ToPagedList(IQueryable<T> source, int pageNumber, int pageSize)
        {
            var count = source.Count();
            var items = source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();

            return new PagedList<T>(items, count, pageNumber, pageSize);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Entities
{
    public interface IRepository<T> :IDisposable where T : BaseEntity
    {
        IEnumerable<T> GetAll( Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            Expression<Func<T, bool>> filter = null,
            Expression<Func<T, IEnumerable<T>>> includeOther = null,
            string includeProperties = "");
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
        T FindById(int id);
        IQueryable<T> FindByProperty(Expression<Func<T, bool>> predicate);
    }
}

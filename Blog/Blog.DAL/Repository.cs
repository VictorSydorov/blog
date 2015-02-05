using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Blog.Entities;
namespace Blog.DAL
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private BlogContext db = null;

        public Repository(string conName)
        {
            db = new BlogContext(conName);
        }

        public IEnumerable<T> GetAll(Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            Expression<Func<T, bool>> filter = null,
            Expression<Func<T, IEnumerable<T>>> includeOther = null,
            string includeProperties = "")
        {
            IQueryable<T> query = db.Set<T>();

            

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }
            if (includeOther != null)
                query = query.Include(includeOther);

            if (orderBy != null)
            {
                query = orderBy(query);
            }

            return query;
        }

      public void Add(T entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException("entity");
                else
                {
                    db.Set<T>().Add(entity);
                    db.SaveChanges();
                }
            }
            catch (DbEntityValidationException e)
            {
                string errorMessage = "";
                foreach (var validationErrors in e.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        errorMessage += string.Format("Property: {0} Error: {1}",
                            validationError.PropertyName, validationError.ErrorMessage) + Environment.NewLine;
                    }
                }
                throw new Exception(errorMessage, e);
            }

        }

      public void Delete(T entity)
      {
          try
          {
              if (entity == null)
                  throw new ArgumentNullException("entity");
              else
              {
                  db.Set<T>().Remove(entity);
                  db.SaveChanges();
              }
          }
          catch (DbEntityValidationException e)
          {
              string errorMessage = "";
              foreach (var validationErrors in e.EntityValidationErrors)
              {
                  foreach (var validationError in validationErrors.ValidationErrors)
                  {
                      errorMessage += string.Format("Property: {0} Error: {1}",
                          validationError.PropertyName, validationError.ErrorMessage) + Environment.NewLine;
                  }
              }
              throw new Exception(errorMessage, e);
          }
      }

      public void Update(T entity)
      {
          try
          {
              if (entity == null)
                  throw new ArgumentNullException("entity");
              else
              {
                  db.SaveChanges();
              }
          }
          catch (DbEntityValidationException e)
          {
              string errorMessage = "";
              foreach (var validationErrors in e.EntityValidationErrors)
              {
                  foreach (var validationError in validationErrors.ValidationErrors)
                  {
                      errorMessage += string.Format("Property: {0} Error: {1}",
                          validationError.PropertyName, validationError.ErrorMessage) + Environment.NewLine;
                  }
              }
              throw new Exception(errorMessage, e);
          }
      }

      public T FindById(int id)
      {
          return db.Set<T>().Find(id);
      }

      public void Dispose()
      {
         if(db!=null)
             db.Dispose();
      }


      public IQueryable<T> FindByProperty(Expression<Func<T,bool>> predicate)
      {
          return db.Set<T>().Where(predicate);
      }
    }
}

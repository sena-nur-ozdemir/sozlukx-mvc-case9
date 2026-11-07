using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using DataAccessLayer.Abstract;

namespace DataAccessLayer.Concrete.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T>
        where T : class
    {
        public List<T> List()
        {
            using (var context = new DictionaryContext())
            {
                return context.Set<T>().ToList();
            }
        }

        public List<T> List(Expression<Func<T, bool>> filter)
        {
            using (var context = new DictionaryContext())
            {
                return context.Set<T>()
                              .Where(filter)
                              .ToList();
            }
        }

        public T GetByID(int id)
        {
            using (var context = new DictionaryContext())
            {
                return context.Set<T>().Find(id);
            }
        }

        public T Get(Expression<Func<T, bool>> filter)
        {
            using (var context = new DictionaryContext())
            {
                return context.Set<T>()
                              .FirstOrDefault(filter);
            }
        }

        public void Insert(T entity)
        {
            using (var context = new DictionaryContext())
            {
                context.Set<T>().Add(entity);
                context.SaveChanges();
            }
        }

        public void Update(T entity)
        {
            using (var context = new DictionaryContext())
            {
                context.Entry(entity).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void Delete(T entity)
        {
            using (var context = new DictionaryContext())
            {
                context.Set<T>().Attach(entity);
                context.Set<T>().Remove(entity);
                context.SaveChanges();
            }
        }
    }
}

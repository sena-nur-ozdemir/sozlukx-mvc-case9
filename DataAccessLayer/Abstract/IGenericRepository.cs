using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DataAccessLayer.Abstract
{
    public interface IGenericRepository<T> where T : class
    {
        List<T> List();
        List<T> List(Expression<Func<T, bool>> filter);

        T GetByID(int id);
        T Get(Expression<Func<T, bool>> filter);

        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}

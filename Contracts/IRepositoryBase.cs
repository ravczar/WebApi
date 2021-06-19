using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Contracts
{

    /// <summary>
    /// Generic repository that will serve us all the CRUD methods. 
    /// As a result, all the methods can be called upon any repository class in our project.
    /// This is a wrapper around repository class and we will inject is in Controllers as a service.
    /// I will instantiate this only once and call it by any repository class.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepositoryBase<T>
    {
        IQueryable<T> FindAll();
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}

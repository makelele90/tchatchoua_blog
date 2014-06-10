using System;
using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;

namespace Blog.Data.Reppository
{
  public interface IRepository<T>
  {
    IQueryable<T> FindAll();
    T Single(Expression<Func<T, bool>> predicate);
    IQueryable<T> Find(Expression<Func<T, bool>> predicate);
    void Add(T entity);
    void Update(T entity);
    void Delete(T entity);
  }
}

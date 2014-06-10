using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Linq.Expressions;


namespace Blog.Data.Reppository
{
  public abstract class GenericRepository<T, TDbContext> : BaseRepository<TDbContext>, IRepository<T>
    where TDbContext : DbContext, new()
    where T:class 
  {

    public IQueryable<T> FindAll()
    {
        return Context.Set<T>();
    }
    public T Single(Expression<Func<T, bool>> predicate)
    {
        return Context.Set<T>().Where(predicate).FirstOrDefault();
    }
    public IQueryable<T> Find(Expression<Func<T, bool>> predicate)
    {
        return Context.Set<T>().Where(predicate);
    }

    public void Add(T entity)
    {
        Context.Set<T>().Add(entity);
    }

    public void Update(T entity)
    {
        Context.Entry(entity).State = EntityState.Modified;   
    }

    public void Delete(T entity)
    {
        Context.Set<T>().Remove(entity);
    }
  }
}

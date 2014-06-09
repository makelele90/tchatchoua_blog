using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Linq.Expressions;


namespace Blog.Data.Reppository
{
  public abstract class GenericRepository<T, TDbContext> :BaseRepository<TDbContext>, IRepository<T> where TDbContext : ObjectContext,new ()
    where T:class 
  {
    readonly IObjectSet<T> _objectSet;

    protected GenericRepository()
    {
      _objectSet = Context.CreateObjectSet<T>();
    }

    public IEnumerable<T> FindAll()
    {
      return _objectSet.ToList();
    }
    public T FindOne(Expression<Func<T, bool>> predicate)
    {
      return _objectSet.Single(predicate);
    }
    public IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
    {
      return _objectSet.Where(predicate);
    }

    public void Add(T entity)
    {
      _objectSet.AddObject(entity);
    }

    public void Update(T entity)
    {
      _objectSet.Attach(entity);
    }

    public void Delete(T entity)
    {
      _objectSet.DeleteObject(entity);
    }
  }
}

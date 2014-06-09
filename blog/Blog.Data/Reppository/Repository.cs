using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Blog.Data.Reppository
{
  public class Repository<T, TDbConetxt> : IRepository<T, TDbConetxt> where TDbConetxt : new()
  {
    private TDbConetxt _dbConetxt;
    public  TDbConetxt DbContext 
    { 
      get{
        if (_dbConetxt!=null)
        {
          return _dbConetxt;
        }

        _dbConetxt=new TDbConetxt();

        return _dbConetxt;
      } 
    }

    public IQueryable<T> FindAll()
    {
      throw new NotImplementedException();
    }

    public IQueryable<T> FindByName(string name)
    {
      throw new NotImplementedException();
    }

    public IQueryable<T> FindByDate(DateTime date)
    {
      throw new NotImplementedException();
    }

    public void Create(T item)
    {
      throw new NotImplementedException();
    }

    public void Update(T item)
    {
      throw new NotImplementedException();
    }

    public void Delete(T item)
    {
      throw new NotImplementedException();
    }
  }
}

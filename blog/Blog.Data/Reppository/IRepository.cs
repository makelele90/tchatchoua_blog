using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Blog.Data.Reppository
{
  public interface IRepository<T,TDbConetxt> where TDbConetxt:new()
  {
    IQueryable<T> FindAll();
    IQueryable<T> FindByName(string name);
    IQueryable<T> FindByDate(DateTime date);
    void Create(T item);
    void Update(T item);
    void Delete(T item);
  }
}

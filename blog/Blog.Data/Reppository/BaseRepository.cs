using System;
using System.Data.Entity.Core.Objects;

namespace Blog.Data.Reppository
{

  public class BaseRepository<TObjectContext> : IDisposable where TObjectContext : ObjectContext, new()
  {

    private TObjectContext _context;

    public TObjectContext Context
    {
      get
      {
        _context = _context ?? new TObjectContext();

        return _context;
      }
    }

    public void Save()
    {
      Context.SaveChanges();
    }

    public void Dispose()
    {
      if (_context != null)
      {

        _context.Dispose();

      }
      GC.SuppressFinalize(this);
    }
  }
}

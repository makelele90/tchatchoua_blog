using System;
using System.Data.Entity;

namespace Blog.Data.Reppository
{

  public abstract class BaseRepository<TDbContext> : IDisposable where TDbContext : DbContext, new()
  {

    private TDbContext _context;

    public TDbContext Context
    {
      get
      {
        _context = _context ?? new TDbContext();
        _context.Configuration.LazyLoadingEnabled = true;

        return _context;
      }
    }

    public void SaveChanges()
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

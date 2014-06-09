using System;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;

namespace Blog.Data.Reppository
{

  public class BaseRepository<TDbContext> : IDisposable where TDbContext : DbContext, new()
  {

    private TDbContext _context;

    public TDbContext Context
    {
      get
      {
        _context = _context ?? new TDbContext();

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

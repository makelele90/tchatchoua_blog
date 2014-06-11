using System.Data.Entity;
using System.Linq;

namespace Blog.Data.Reppository
{
  public class BlogPostRepository : GenericRepository<BlogPost, BlogDataContext>
  {

    //public BlogPost Single(int id)
    //{
    //  return Context.Posts.Where(p => p.Id == id).Include(p => p.Category).FirstOrDefault();
    //}
  }
}

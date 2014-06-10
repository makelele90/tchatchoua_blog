

using System.Collections.Generic;

namespace Blog.Data
{
  public class Role
  {
    public Role()
    {
      Users=new HashSet<User>();
    }
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public ICollection<User> Users { get; set; }
  }
}

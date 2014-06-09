using System;

namespace Blog.Data
{
  public class BlogPost
  {
    public int Id { get; set; }
    public string Title { get; set; }
    public string Details { get; set; }
    public DateTime DateCreated { get; set; }
    public DateTime DateUpdated { get; set; }
    public User CreatedBy { get; set; }
    public User LastUpdatedBy { get; set; }
  }
}

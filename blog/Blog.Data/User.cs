using System;
namespace Blog.Data
{
  public class User
  {
    public int Id { get; set; }
    public string FirstName  { get; set; }
    public string LastName { get; set; }
    public string Avatar { get; set; }
    public DateTime JoinDate { get; set; }
    public DateTime LastLogin { get; set; }
  }
}

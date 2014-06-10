using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace blog.Codes.Authentication
{
  public class SerializableUser
  {
    public string UserName { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string[] Roles { get; set; }
  }
}
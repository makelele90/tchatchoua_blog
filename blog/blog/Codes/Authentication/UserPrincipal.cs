

using System.Linq;
using System.Security.Principal;

namespace blog.Codes.Authentication
{
  public class UserPrincipal:IPrincipal
  {
    public string UserName { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string[] Roles { get; set; }

    public UserPrincipal(string username)
    {
      Identity=new GenericIdentity(username);
    }
    public IIdentity Identity { get; private set; }

    public bool IsInRole(string role)
    {
      return Roles.Any(r => Roles.Contains(role));
    }
  }
}
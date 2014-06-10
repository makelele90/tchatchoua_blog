
using System.Web.Mvc;
using blog.Codes.Authentication;

namespace blog.Codes
{
  public class BaseController : Controller
  {
    
    protected virtual new UserPrincipal User
    {
      get { return HttpContext.User as UserPrincipal; }
    }
  }
}
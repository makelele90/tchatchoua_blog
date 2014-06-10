
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace blog.Codes.Authentication
{
  public class AuthenticationAttribute : AuthorizeAttribute
  {
    public string AuthorizedRoles { get; set; }
   

    protected virtual UserPrincipal CurrentUser
    {
      get { return HttpContext.Current.User as UserPrincipal; }
    }

    public override void OnAuthorization(AuthorizationContext filterContext)
    {
      var isAuthencicated = false;

      if (filterContext.HttpContext.Request.IsAuthenticated)
      {
        var authorizedRoles = AuthorizedRoles.Split(',');

        if (authorizedRoles.Length >0)
        {
          if (CurrentUser.Roles!=null)
          {
            foreach (var role in CurrentUser.Roles)
            {
              if (authorizedRoles.Contains(role))
              {
                isAuthencicated = true;
              }

            }
          }
          
        }
        else
        {
          isAuthencicated = true;
        }

      }

      if (!isAuthencicated)
      {
        filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new
        {
          controller = "Error",
          action = "Index"
        }));
      }
     
      base.OnAuthorization(filterContext);
    }
  }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using Newtonsoft.Json;
using Ninject;
using blog.App_Start;
using blog.Codes.Authentication;
using blog.Codes.Services;

namespace blog
{
  // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
  // visit http://go.microsoft.com/?LinkId=9394801

  public class MvcApplication : System.Web.HttpApplication
  {
    protected void Application_Start()
    {
      AreaRegistration.RegisterAllAreas();

      WebApiConfig.Register(GlobalConfiguration.Configuration);
      FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
      RouteConfig.RegisterRoutes(RouteTable.Routes);
      BundleConfig.RegisterBundles(BundleTable.Bundles);
      AuthConfig.RegisterAuth();
    }

    protected void Application_PostAuthenticateRequest(Object sender, EventArgs e)
     {
       HttpCookie authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];

       if (authCookie!=null)
       {
         var authTicket = FormsAuthentication.Decrypt(authCookie.Value);

         var deserializedModel = JsonConvert.DeserializeObject<SerializableUser>(authTicket.UserData);

         var userPrincipal = new UserPrincipal(deserializedModel.UserName)

           {
             FirstName = deserializedModel.FirstName,
             LastName = deserializedModel.LastName,
             Roles = deserializedModel.Roles
           };

         HttpContext.Current.User = userPrincipal;
       }

     }
  }
}
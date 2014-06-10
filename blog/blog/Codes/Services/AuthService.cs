using System;
using System.Linq;
using System.Web;
using System.Web.Security;
using Blog.Data;
using Blog.Data.Reppository;
using Newtonsoft.Json;
using blog.Codes.Authentication;

namespace blog.Codes.Services
{
  public class AuthService : IAuthService
  {
    private readonly UserRepository _repository;
    public AuthService()
    {
      _repository = new UserRepository();
    }
    public bool Login(string username, string password, bool remember)
    {

      var user = _repository.Single(u => u.UserName == username && u.Password == password);

      if (user != null)
      {
        var roles =user.Roles.Any()?  user.Roles.Select(r => r.Name).ToArray():null;

        var serializableModel = new SerializableUser
          {
            UserName = user.UserName,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Roles = roles
          };

        var userData = JsonConvert.SerializeObject(serializableModel);

        var authTicket = new FormsAuthenticationTicket(1, user.UserName, DateTime.Now, DateTime.Now.AddDays(1), remember,
                                                       userData);

        string encTicket = FormsAuthentication.Encrypt(authTicket);

        var faCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encTicket);

        //TODO: Remove this depedency
        HttpContext.Current.Response.Cookies.Add(faCookie);

        return true;

      }

      return false;
    }
  }
}
using System;
using System.Linq;
using System.Web;
using System.Web.Security;
using Blog.Data.Reppository;
using Newtonsoft.Json;
using blog.Codes.Authentication;
using blog.Codes.DTO;
using blog.Models;
using Blog.Data;

namespace blog.Codes.Services
{
  public class AuthService : IAuthService
  {

    private readonly UserRepository _userRepository;

    public AuthService(UserRepository userRepository)
    {
      _userRepository = userRepository;
    }

    public OperationStatus Login(string username, string password, bool remember)
    {
      var operationStatus = new OperationStatus();
      try
      {
        var user = _userRepository.Single(u => u.UserName == username && u.Password == password);

        if (user != null)
        {
          var roles = user.Roles.Any() ? user.Roles.Select(r => r.Name).ToArray() : null;

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

          operationStatus.Status = true;

        }

        operationStatus.Status = false;
        operationStatus.Message = "Sorry incorrect username or password!";
      }
      catch (Exception ex)
      {
        //TODO: Log exception using elmah

        operationStatus.Status = false;
        operationStatus.Message = "Sorry wrong happen we can not log you in at this moment";
        throw;
      }
      return operationStatus;
    }
    public OperationStatus RegisterUser(RegisterViewModel model)
    {
      var operation = new OperationStatus();
      try
      {

        var restrivedUser = _userRepository.Single(u => u.UserName.ToLower() == model.UserName.ToLower());

        if (restrivedUser==null)
        {
          var user = new User
          {
            UserName = model.UserName,
            FirstName = model.FirstName,
            LastName = model.LastName,
            Password = model.Password,
            Email = model.Email,
            JoinDate = DateTime.Now,
            Avatar = string.Format("{0}_{1}", model.UserName, model.ImageName)


          };

          _userRepository.Add(user);

          operation.Status = true;
        }
        else
        {
          //create message to say user already exist

          operation.Status = false;
          operation.Message = "A user with the same username already exist";
        }
        
        
      }
      catch (Exception ex)
      {
        //TODO: Log exeption using elmah
        operation.Status = false;
        operation.Message = "Sorry registration failed try again later";

        throw;
      }
      return operation;
    }

  }
}
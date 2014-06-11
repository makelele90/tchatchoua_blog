using System.IO;
using System.Web;
using System.Web.Mvc;
using Blog.Data;
using blog.Codes.Authentication;
using blog.Codes.Services;
using blog.Models;

namespace blog.Controllers
{

  public class AccountController : Controller
  {
    private readonly IAuthService _authService;

    public AccountController(IAuthService authService)
    {
      _authService = authService;
    }

    [AllowAnonymous]
    public ActionResult Login(string returnUrl)
    {
      var model = new LoginViewModel(){ReturnUrl = returnUrl};
      return View(model);
    }

    [AllowAnonymous]
    [HttpPost]
    public ActionResult Login(LoginViewModel model, string returnUrl)
    {

      if (ModelState.IsValid)
      {

        var operationStatus = _authService.Login(model.UserName, model.Password, model.RememberMe);

        if (operationStatus.Status)
        {
           return new RedirectResult(returnUrl);
        }

         ModelState.AddModelError("", operationStatus.Message);
      }
     
        return View(model);
    }

   // [Authentication(AuthorizedRoles = "Admin")]
    public ActionResult Register()
    {
      var model = new RegisterViewModel();
      return View(model);
    }

    [HttpPost]
    public ActionResult Register(RegisterViewModel model, HttpPostedFileBase avatar)
    {
      if (ModelState.IsValid)
      {
        if (avatar != null) model.ImageName = Path.GetFileName(avatar.FileName);
        
        var operationStatus= _authService.RegisterUser(model);

        if (operationStatus.Status)
        {
          return new RedirectResult("/Home/Index");
        }

        ModelState.AddModelError("", operationStatus.Message);
      }
      return View(model);

      //upload file
      //http://haacked.com/archive/2010/07/16/uploading-files-with-aspnetmvc.aspx/
    }
  }
}

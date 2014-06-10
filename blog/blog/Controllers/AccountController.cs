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
      var model = new UserViewModel(){ReturnUrl = returnUrl};
      return View(model);
    }

    [AllowAnonymous]
    [HttpPost]
    public ActionResult Login(UserViewModel model, string returnUrl)
    {

      if (ModelState.IsValid)
      {

        var isAuthenticated = _authService.Login(model.UserName, model.Password, model.RememberMe);

        if (isAuthenticated)
        {
           return new RedirectResult(returnUrl);
        }
      }
        ModelState.AddModelError("","Username or Password is Invalid");
        return View(model);
    }

    [Authentication(AuthorizedRoles = "Admin")]
    public ActionResult Register()
    {
      return View();
    }
  }
}

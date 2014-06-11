using System.Web.Mvc;
using blog.Codes;
using blog.Codes.Services;

namespace blog.Controllers
{
  [AllowAnonymous]
  public class HomeController : BaseController
  {
    
    public ActionResult Index()
    {
      ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

      return View();
    }
  }
}

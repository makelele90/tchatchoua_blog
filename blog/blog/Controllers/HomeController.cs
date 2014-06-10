using System.Web.Mvc;
using blog.Codes;
using blog.Codes.Services;

namespace blog.Controllers
{
  [Authorize]
  public class HomeController : BaseController
  {
    private readonly IAuthService _service;

    public HomeController(IAuthService service)
    {
      _service = service;
    }

    public ActionResult Index()
    {
      ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

      return View();
    }

    public ActionResult About()
    {
      ViewBag.Message = "Your app description page.";

      return View();
    }

    public ActionResult Contact()
    {
      ViewBag.Message = "Your contact page.";

      return View();
    }
  }
}

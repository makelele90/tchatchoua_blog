using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using blog.Models;

namespace blog.Controllers
{
    public class CommentController : Controller
    {
        //
        // GET: /Comment/

        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult Create(CommentViewModel model)
        {
          ViewData.Model = model;

          return RedirectToAction("Detail", "Post",model);
        }

    }
}

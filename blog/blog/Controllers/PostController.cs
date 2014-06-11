using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Blog.Data;
using blog.Codes.Services;
using blog.Models;

namespace blog.Controllers
{
    [AllowAnonymous]
    public class PostController : Controller
    {
      private readonly IBloggingService _bloggingService;

      public PostController(IBloggingService bloggingService)
      {
        _bloggingService = bloggingService;
      }

      public ActionResult Index()
      {
        var blogPosts = _bloggingService.GetAllPost();
        return View(blogPosts);
      }

        public ActionResult Create()
        {
          var model = new PostViewModel();
         
           var categories= _bloggingService.GetAllCategories();

          var enumerableCategory = categories as IList<Category> ?? categories.ToList();

          if (enumerableCategory.Any())
           {
             var selectList = enumerableCategory.Select(c => new SelectListItem()
               {
                 Text = c.Name,
                 Value = c.Id.ToString(),
               }).ToList();

            selectList.Insert(0, new SelectListItem() { Text = "---select category---", Value = "-1", Selected = true });
             ViewBag.Categories=selectList;
           }

          return View(model);
        }

        [HttpPost]
        public ActionResult Create(PostViewModel model)
        {
          if (ModelState.IsValid)
          {
            var operationStatus = _bloggingService.AddPost(model);

            if (operationStatus.Status)
            {
              return new RedirectResult("/blog/post");
            }

          }
          
          return View(model);
        }

    }
}

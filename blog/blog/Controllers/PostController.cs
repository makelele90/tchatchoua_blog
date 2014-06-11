using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
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
     

        public ActionResult Detail(int id)
        {

          var model = _bloggingService.GetPost(id);
          model.Id = id;
          return View(model);
        }
        
       public ActionResult Delete(int id)
       {
         var operationStatus = _bloggingService.DeletePost(id);

         if (operationStatus.Status)
         {
           return RedirectToAction("Index");
         }

         return null;
       }

      public ActionResult Edit(int id)
      {

        var model = _bloggingService.GetPost(id);


        var categories = _bloggingService.GetAllCategories();

        var enumerableCategory = categories as IList<Category> ?? categories.ToList();

        if (enumerableCategory.Any())
        {
          var selectList = enumerableCategory.Select(c => new SelectListItem()
          {
            Text = c.Name,
            Value = c.Id.ToString(),
            Selected = c.Id==model.Category
          }).ToList();

          ViewBag.Categories = selectList;
        }

        return View(model);
      }

      [HttpPost]
      public ActionResult Edit(PostViewModel model)
      {
        if (ModelState.IsValid)
        {
          var operationStatus = _bloggingService.UpdatePost(model);

          if (operationStatus.Status)
          {
            return RedirectToAction("Detail", new { id = model.Id });
          }

          ModelState.AddModelError("",operationStatus.Message);
        }
        
        return View(model);
      }
    }
}

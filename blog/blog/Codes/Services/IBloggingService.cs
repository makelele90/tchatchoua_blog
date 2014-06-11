using System.Collections.Generic;
using blog.Codes.DTO;
using blog.Models;
using Blog.Data;


namespace blog.Codes.Services
{
  public interface IBloggingService
  {
    OperationStatus AddPost(PostViewModel model);
    OperationStatus DeletePost(int postId);
    OperationStatus UpdatePost(PostViewModel model);
    PostViewModel GetPost(int postId);
    IEnumerable<PostViewModel> GetAllPost();
    IEnumerable<Category> GetAllCategories();

  }
}
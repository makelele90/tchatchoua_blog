using System;
using System.Collections.Generic;
using Blog.Data;
using Blog.Data.Reppository;
using blog.Codes.DTO;
using blog.Models;
using System.Linq;

namespace blog.Codes.Services
{
  public class BloggingService : IBloggingService
  {
    private readonly BlogPostRepository _blogRepository;
    private readonly CategoryRepository _categoryRepository;

    public BloggingService(BlogPostRepository blogRepository, CategoryRepository categoryRepository)
    {
      _blogRepository = blogRepository;
      _categoryRepository = categoryRepository;
    }
    public OperationStatus AddPost(PostViewModel model)
    {
      var operationStatus = new OperationStatus();
      try
      {
        var blogPost = new BlogPost
        {
          Title = model.Title,
          Details = model.Details,
          DateCreated = DateTime.Now,
          CategoryId = model.Category
          
        };

        _blogRepository.Add(blogPost);

       

        operationStatus.Status = true;

      }
      catch (Exception ex)
      {
        operationStatus.Status = false;
        operationStatus.Message = "Sorry was not able to create your post, try again later";
        throw;
      }

      return operationStatus;

    }

    public OperationStatus DeletePost(int postId)
    {
      var operationStatus = new OperationStatus();

      try
      {
        var blogPost = _blogRepository.Single(post => post.Id == postId);

        if (blogPost != null)
        {
          _blogRepository.Delete(blogPost);
        }

        operationStatus.Status = true;
      }
      catch (Exception ex)
      {
        operationStatus.Status = false;
        operationStatus.Message = "Sorry was not able to Remove your post, try again later";
        throw;
      }

      return operationStatus;
    }

    public OperationStatus UpdatePost(PostViewModel model)
    {
      var operationStatus = new OperationStatus() { Status = false };

      try
      {
        var blogPost = _blogRepository.Single(p => p.Id == model.Id);

        if (blogPost != null)
        {

          blogPost.Title = model.Title;
          blogPost.Details = model.Details;
          blogPost.CategoryId = model.Category;

          _blogRepository.Update(blogPost);

          operationStatus.Status = true;
        }
      }
      catch (Exception ex)
      {
        operationStatus.Message = "Sorry could not update post details";
        throw;
      }

      return operationStatus;
    }

    public PostViewModel GetPost(int postId)
    {


      var blogPost = _blogRepository.Single(p=>p.Id==postId);

      if (blogPost != null)
      {
        return new PostViewModel()
        {
          Id = blogPost.Id,
          Title = blogPost.Title,
          Details = blogPost.Details,
          DateCreated = blogPost.DateCreated,
          Category = blogPost.CategoryId
          
        };
      }

      return null;
    }

    public IEnumerable<PostViewModel> GetAllPost()
    {
      var blogPosts = _blogRepository.FindAll();


      if (blogPosts.Any())
      {
        var postViewModels = blogPosts.Select(p => new PostViewModel()
          {
            Title = p.Title,
            Details = p.Details,
            DateCreated = p.DateCreated,
            Id = p.Id
          });

        return postViewModels;
      }

      return null;
    }


    public IEnumerable<Category> GetAllCategories()
    {
      return _categoryRepository.FindAll();
    }
  }
}
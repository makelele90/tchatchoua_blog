
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Collections;
using Blog.Data;

namespace blog.Models
{
  public class PostViewModel
  {
    public int Id { get; set; }
    [Required]
    public string Title { get; set; }
    [Required]
    public string Details { get; set; }
    public DateTime DateCreated { get; set; }
    public int Category { get; set; }
  }
}
﻿using System;

namespace Blog.Data
{
  public class PostComment
  {
    public BlogPost Post { get; set; }
    public User Commenter { get; set; }
    public DateTime DateAdded { get; set; }
  }
}

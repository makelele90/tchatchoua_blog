using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace blog.Models
{
  public class CommentViewModel
  {
    public int Id { get; set; }
    public string Details { get; set; }
    public RegisterViewModel User { get; set; }
    public int PostId { get; set; }
  }
}
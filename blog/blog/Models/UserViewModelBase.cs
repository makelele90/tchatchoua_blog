using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace blog.Models
{
  public abstract class UserViewModelBase
  {
    [DisplayName("User Name")]
    [Required]
    public string UserName { get; set; }

    [Required]
    public string Password { get; set; }

    [DisplayName("Confirm Password")]
    [Required]
    [Compare("Password")]
    public string ConfirmPassword { get; set; }
  }
}
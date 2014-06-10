using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace blog.Models
{
  public class UserViewModel
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

    [DisplayName("Remember Me?")]
    public bool RememberMe { get; set; }

    public string ReturnUrl { get; set; }

  }
}
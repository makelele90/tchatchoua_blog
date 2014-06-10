using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace blog.Models
{
  public class LoginViewModel : UserViewModelBase
  {
    [DisplayName("Remember Me?")]
    public bool RememberMe { get; set; }
    public string ReturnUrl { get; set; }

  }
}
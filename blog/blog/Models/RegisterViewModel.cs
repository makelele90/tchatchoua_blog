using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace blog.Models
{
  public class RegisterViewModel : UserViewModelBase
  {
    [Required]
    public string Email { get; set; }
    [Required]
    [DisplayName("Confirm Email")]
    public string ConfirmEmail { get; set; }
    [Required]
    [DisplayName("Fist Name")]
    public string FirstName { get; set; }
    [Required]
    [DisplayName("Last Name")]
    public string LastName { get; set; }

    public string ImageName { get; set; }
  }
}
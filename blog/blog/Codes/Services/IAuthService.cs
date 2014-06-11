using blog.Codes.DTO;
using blog.Models;

namespace blog.Codes.Services
{
  public interface IAuthService
  {
    OperationStatus Login(string username, string password, bool remember);
    OperationStatus RegisterUser(RegisterViewModel registrationData);
  }
}
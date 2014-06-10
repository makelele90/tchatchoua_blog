
using Blog.Data;

namespace blog.Codes.Services
{
  public interface IAuthService
  {
    bool Login(string username,string password, bool remember);
  }
}
using Ninject.Modules;
using blog.Codes.Services;

namespace blog.Codes.DepedencyInjection
{
  public class DepedencyModule:NinjectModule
  {
    public override void Load()
    {
      Bind<IAuthService>().To<AuthService>();
    }
  }
}
﻿using Blog.Data.Reppository;
using Ninject.Modules;
using blog.Codes.Services;

namespace blog.Codes.DepedencyInjection
{
  public class DepedencyModule:NinjectModule
  {
    public override void Load()
    {
      Bind<IAuthService>().To<AuthService>();
      Bind<IBloggingService>().To<BloggingService>();
      Bind<BlogPostRepository>().To<BlogPostRepository>();
      Bind<CategoryRepository>().To<CategoryRepository>();
      Bind<UserRepository>().To<UserRepository>();
    }
  }
}
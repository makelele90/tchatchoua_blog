using System.Web.Mvc;
using blog.Codes.Authentication;

namespace blog.Codes
{
  public abstract class ViewBase<TModel>:WebViewPage<TModel>
  {
    protected virtual new UserPrincipal User
    {
      get { return base.User as UserPrincipal; }
    }

    public override void Execute()
    {
      
    }
  }

  public abstract class ViewBase:WebViewPage
  {
    protected virtual new UserPrincipal User
    {
      get { return base.User as UserPrincipal; }
    }

    public override void Execute()
    {

    }
  }
}
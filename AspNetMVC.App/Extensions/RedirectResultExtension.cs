using System.Web.Mvc;

namespace AspNetMVC.App.Extensions
{
    public static class RedirectResultExtension
    {
        public static RedirectResult RedirectTo(this Controller controller, string url)
        {
            return new RedirectResult(url);
        }

        public static RedirectResult RedirectTo(this FilterAttribute controller, string url)
        {
            return new RedirectResult(url);
        }

    }
}
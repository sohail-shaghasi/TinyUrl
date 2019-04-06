using System.Web;
using System.Web.Mvc;

namespace Nintex_TinyUrl
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}

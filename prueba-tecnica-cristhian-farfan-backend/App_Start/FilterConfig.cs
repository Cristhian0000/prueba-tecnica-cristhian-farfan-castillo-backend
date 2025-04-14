using System.Web;
using System.Web.Mvc;

namespace prueba_tecnica_cristhian_farfan_backend
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}

using System.Web;
using System.Web.Mvc;

namespace pnthanh_k22cntt_2210900066_prj2
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}

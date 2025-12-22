using System.Web;
using System.Web.Mvc;

namespace MISA.HKD.SHOPEE
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}

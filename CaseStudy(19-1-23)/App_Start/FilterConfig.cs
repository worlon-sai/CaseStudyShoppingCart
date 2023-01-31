using System.Web;
using System.Web.Mvc;

namespace CaseStudy_19_1_23_
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}

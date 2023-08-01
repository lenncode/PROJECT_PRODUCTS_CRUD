using System.Web;
using System.Web.Mvc;

namespace CL3_POO_SOLORZANO_MELENDEZ_SAM
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}

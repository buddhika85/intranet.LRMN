using MvcClient.Filters;
using System.Web.Mvc;

namespace MvcClient
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());

            // global level logging
            filters.Add(new LogAttribute());
        }
    }
}

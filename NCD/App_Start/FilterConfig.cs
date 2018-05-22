

namespace NCD
{
    using System.Web;
    using System.Web.Mvc;

    public static class FilterConfig
    {
        /// <summary>
        /// Enable global filters
        /// </summary>
        /// <param name="filters"></param>
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}

﻿using System.Web;
using System.Web.Mvc;

namespace Parliament.JargonBuster.BackEndAdminApp
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}

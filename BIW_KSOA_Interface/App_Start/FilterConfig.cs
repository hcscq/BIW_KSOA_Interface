﻿using System.Web;
using System.Web.Mvc;

namespace BIW_KSOA_Interface
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
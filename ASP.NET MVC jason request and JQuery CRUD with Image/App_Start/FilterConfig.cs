﻿using System.Web;
using System.Web.Mvc;

namespace ASP.NET_MVC_jason_request_and_JQuery_CRUD_with_Image
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}

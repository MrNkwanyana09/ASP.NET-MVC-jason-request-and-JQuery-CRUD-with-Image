using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ASP.NET_MVC_jason_request_and_JQuery_CRUD_with_Image.Models
{
    public class ContextClass:DbContext
    {
        public ContextClass() : base("Staff")
        {

        }
        public virtual DbSet<Employee> Employees { get; set; }
        
    }
}
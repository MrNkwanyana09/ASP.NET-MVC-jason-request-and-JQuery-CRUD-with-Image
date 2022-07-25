using ASP.NET_MVC_jason_request_and_JQuery_CRUD_with_Image.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASP.NET_MVC_jason_request_and_JQuery_CRUD_with_Image.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult ViewAll()
        {
            return View(GetAllItems());
        }

        IEnumerable<Employee> GetAllItems()
        {
            using (ContextClass db = new ContextClass())
            {
                return db.Employees.ToList<Employee>();
            }
        }


        public ActionResult AddOrEdit(int id = 0)
        {
            Employee employee = new Employee();
            if (id != 0)
            {
                using (ContextClass db = new ContextClass())
                {
                    employee = db.Employees.Where(x => x.EmployeeId == id).FirstOrDefault<Employee>();

                }
            }
            return View(employee);
        }


        [HttpPost]
        public ActionResult AddOrEdit(Employee employee)
        {
            try
            {
                if (employee.ImageUpload != null)
                {
                    string filename = Path.GetFileNameWithoutExtension(employee.ImagePath);
                    string extension = Path.GetExtension(employee.ImagePath);
                    filename = filename + DateTime.Now.ToString("yymmssfff") + extension;
                    employee.ImagePath = "~/AppFiles/Images/" + filename;
                    employee.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/AppFiles/Images/"), filename));
                }
                using (ContextClass db = new ContextClass())
                {
                    if (employee.EmployeeId == 0)
                    {
                        db.Employees.Add(employee);
                        db.SaveChanges();
                    }
                    else
                    {
                        db.Entry(employee).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                }
                return Json(new { success = true, html = GlobalClass.RenderRazorViewToString(this, "ViewAll", GetAllItems()), message = "Submitted Successfully" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                return Json(new { success = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
            }

        }

        public ActionResult Delete(int id)
        {
            try
            {
                using (ContextClass db = new ContextClass())
                {
                    Employee employee = db.Employees.Where(x => x.EmployeeId == id).FirstOrDefault<Employee>();
                    db.Employees.Remove(employee);
                    db.SaveChanges();
                }
                return Json(new { success = false, message = "Deleted Successfully" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}
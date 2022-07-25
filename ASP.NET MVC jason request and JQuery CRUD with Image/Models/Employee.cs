using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ASP.NET_MVC_jason_request_and_JQuery_CRUD_with_Image.Models
{
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name ="ID")]
        public int EmployeeId { get; set; }
        [Required(ErrorMessage = "Employee Name is required")]
        [Display(Name = "Employee Name")]
        public string EmployeeName { get; set; }
        public string ImagePath { get; set; }
        [Required(ErrorMessage = "Department is required")]
        [Display(Name = "Department")]
        public string Department { get; set; }
        

        [NotMapped]
        public HttpPostedFileBase ImageUpload { get; set; }

        public Employee()
        {

            ImagePath = "~/AppFiles/Images/defaultImage.jpg";

        }
    }
}
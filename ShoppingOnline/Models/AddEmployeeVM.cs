using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ShoppingOnline.Models
{
    public class AddEmployeeVM
    {
        [Required]
        [Display(Name = "Employee Name")]

        public string EmployeeName { get; set; }
        [Required]

        public int DepartmentId { get; set; }
        [Required]
        [Display(Name = "Contact Number")]

        public string ContactNumber { get; set; }
        [Required]

        public string Address { get; set; }
        [Required]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]

        public string EmailAddress { get; set; }
        [Required]

        public int CompanyId { get; set; }

        public int EmployeeId { get; set; }

        public IEnumerable<SelectListItem> DepartmentList { get; set; }
    }
}

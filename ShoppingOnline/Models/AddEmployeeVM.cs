using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ShoppingOnline.Models
{
    public class AddEmployeeVM
    {
        public string EmployeeName { get; set; }
        public string Department { get; set; }
        public string ContactNumber { get; set; }
        public string Address { get; set; }
        public string EmailAddress { get; set; }
        public IEnumerable<SelectListItem> DepartmentList { get; set; }
    }
}

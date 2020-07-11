using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ShoppingOnline.Models
{
    public class AddOfficerVM
    {
        public string OfficerName { get; set; }
        public int DepartmentId { get; set; }
        public string ContactNumber { get; set; }
        public string Address { get; set; }
        public string EmailAddress { get; set; }
        public IEnumerable<SelectListItem> DepartmentList { get; set; }
    }
}

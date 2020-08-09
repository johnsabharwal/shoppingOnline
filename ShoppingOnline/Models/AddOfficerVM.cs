using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ShoppingOnline.Models
{
    public class AddOfficerVM
    {
        [Required]
        [Display(Name = "Officer Name")]
        public string OfficerName { get; set; }

        [Required]
        public int DepartmentId { get; set; }


        [Required]
        [Display(Name = "Contact Number")]

        public string ContactNumber { get; set; }
        [Required]

        public string Address { get; set; }
        [Required]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
        [Display(Name = "Email Address")]

        public string EmailAddress { get; set; }
        [Required]

        public int OfficerId { get; set; }
        [Required]

        public int CompanyId { get; set; }
        public IEnumerable<SelectListItem> DepartmentList { get; set; }
    }
}

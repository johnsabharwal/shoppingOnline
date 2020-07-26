using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingOnline.Models
{
    public class AddDepartmentVM
    {
        [Required]
        [Display(Name = "Department Name")]
        public string DepartmentName { get; set; }
        [Required]
        [Display(Name = "Officer Incharge Name")]

        public string OfficerInchargeName { get; set; }
        [Required]
        [Display(Name = "Contact Number")]

        public string ContactNumber { get; set; }
        [Required]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
        [Display(Name = "Email Address")]

        public string EmailAddress { get; set; }
        [Required]
        public int CompanyId { get; set; }
        public int DepartmentId { get; set; }
    }
}

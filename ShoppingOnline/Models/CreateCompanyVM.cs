using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Dal;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ShoppingOnline.Models
{
    public class CreateCompanyVM
    {
        public int id { get; set; }
        [Required]

        public string Name { get; set; }
        public string CompanyName { get; set; }
        public string UserName { get; set; }
        [Required]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]

        public string EmailId { get; set; }
        [Required]

        public string Password { get; set; }
        [Required]

        public string Contact { get; set; }
        public int CountryId { get; set; }
        public int BusinessTypeId { get; set; }
        public IEnumerable<SelectListItem> BusinessTypeList { get; set; }
        public IEnumerable<SelectListItem> CountryList { get; set; }
        [Required]

        public string Address { get; set; }
    }
}

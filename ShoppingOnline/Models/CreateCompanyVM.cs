using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dal;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ShoppingOnline.Models
{
    public class CreateCompanyVM
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string CompanyName { get; set; }
        public string UserName { get; set; }
        public string EmailId { get; set; }
        public string Password { get; set; }
        public string Contact { get; set; }
        public int CountryId { get; set; }
        public int BusinessTypeId { get; set; }
        public IEnumerable<SelectListItem> BusinessTypeList { get; set; }
        public IEnumerable<SelectListItem> CountryList { get; set; }
        public string Address { get; set; }
    }
}

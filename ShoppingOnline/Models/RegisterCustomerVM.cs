using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ShoppingOnline.Models
{
    public class RegisterCustomerVM
    {
         public int Id { get; set; }
        public string UserName { get; set; }
        public string EmailId { get; set; }
        public string Password { get; set; }
        public string Contact { get; set; }
        public int CountryId { get; set; }
        public int StateId { get; set; }
        public string Address { get; set; }
        public string Pincode { get; set; }
        public IEnumerable<SelectListItem> StateList { get; set; }
        public IEnumerable<SelectListItem> CountryList { get; set; }
    }
}

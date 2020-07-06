using System;
using System.Collections.Generic;
using System.Text;

namespace Dal.DTO
{
    public class RegisterCompanyDTO
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
        public string Address { get; set; }
    }
}

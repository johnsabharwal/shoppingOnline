using System;
using System.Collections.Generic;
using System.Text;

namespace Dal.Entities
{
    public class Customer
    {
        public int Id { get; set; }
        public string  Name{ get; set; }
        public string Address { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string EmailId { get; set; }
        public string ContactNumber { get; set; }
        public int CountryId { get; set; }
        public int StateId { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Dal.Entities
{

    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string OwnerName { get; set; }
        public string EmailAddress { get; set; }
        public string ContactNumber { get; set; }
        public int CountryId { get; set; }
        public int BusinessTypeId { get; set; }
        public string Address { get; set; }
        public ICollection<Department> Department { get; set; }
        public ICollection<Officer> Officer { get; set; }
        public ICollection<Product> Product { get; set; }
        public ICollection<Promoter> Promoter { get; set; }
        public ICollection<Supplier> Supplier { get; set; }
        public ICollection<Employee> Employee { get; set; }
    }
}

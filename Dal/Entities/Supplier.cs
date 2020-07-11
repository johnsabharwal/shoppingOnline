using System;
using System.Collections.Generic;
using System.Text;

namespace Dal.Entities
{
   public class Supplier
    {
        public int Id { get; set; }
        public string SupplierName { get; set; }
        public string ContactNumber { get; set; }
        public string EmailAddress { get; set; }
        public string Address { get; set; }
        public int CompanyId { get; set; }
        public Company Company { get; set; }

    }
}

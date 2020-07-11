using System;
using System.Collections.Generic;
using System.Text;

namespace Dal.Entities
{
   public class Promoter
    {
        public int Id { get; set; }
        public string PromoterName { get; set; }
        public string ContactNumber { get; set; }
        public string EmailAddress { get; set; }
        public string Address { get; set; }
        public int CompanyId { get; set; }
        public Company Company { get; set; }

    }
}

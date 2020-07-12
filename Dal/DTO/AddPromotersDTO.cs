using System;
using System.Collections.Generic;
using System.Text;

namespace Dal.DTO
{
    public class AddPromotersDTO
    {
        public string PromoterName { get; set; }
        public string Address { get; set; }
        public string ContactNumber { get; set; }
        public string EmailAddress { get; set; }
        public int CompanyId { get; set; }
        public int PromoterId { get; set; }
    }
}

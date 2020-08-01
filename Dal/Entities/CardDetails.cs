using System;
using System.Collections.Generic;
using System.Text;

namespace Dal.Entities
{
    public class CardDetails
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string CardNo { get; set; }
        public string CardCvv { get; set; }
        public string CardExpiry { get; set; }
        public Customer Customer { get; set; }
    }
}

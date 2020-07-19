using System;
using System.Collections.Generic;
using System.Text;

namespace Dal.DTO
{
    public class PlaceOrderDTO
    {

        public string CardNo { get; set; }
        public string CardExpiry { get; set; }
        public string CardName { get; set; }
        public string PaymentType { get; set; } = "Credit";
        public string Cvv { get; set; }
        public string Cart { get; set; }
        public int Total { get; set; }
    }
}

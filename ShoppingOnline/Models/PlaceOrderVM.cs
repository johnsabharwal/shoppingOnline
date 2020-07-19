using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingOnline.Models
{
    public class PlaceOrderVM
    {
        public PlaceOrderVM()
        {
            User = new RegisterCustomerVM();
        }
        public RegisterCustomerVM User { get; set; }
        public string CardNo { get; set; }
        public string CardExpiry { get; set; }
        public string CardName { get; set; }
        public string PaymentType { get; set; } = "Credit";
        public string Cvv { get; set; }
        public string Cart { get; set; }
        public int Total { get; set; }

    }


}

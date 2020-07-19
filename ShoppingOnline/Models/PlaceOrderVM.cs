using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingOnline.Models
{
    public class PlaceOrderVM
    {
        public int UserId { get; set; }
        public int CardNo { get; set; }
        public string CardExpiry { get; set; }
        public string CardName { get; set; }
        public string PaymentType { get; set; }
        public int Cvv { get; set; }
        public  List<Cart> Cart { get; set; }
    }

    public class Cart
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}

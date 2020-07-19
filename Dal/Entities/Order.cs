using System;
using System.Collections.Generic;
using System.Text;

namespace Dal.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public int Total { get; set; }
        public string PaymentType { get; set; }
        public int CustomerId { get; set; }
        public int OrderStatusId { get; set; }

        public OrderStatus OrderStatus { get; set; }
        public Customer Customer { get; set; }

    }
}

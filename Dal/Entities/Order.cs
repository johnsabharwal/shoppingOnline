using System;
using System.Collections.Generic;
using System.Text;
using Dal.DTO;

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
        public ICollection<OrderDetail> OrderDetails { get; set; }
        public ICollection<TrackOrder> TrackOrders { get; set; }

        public OrderStatus OrderStatus { get; set; }
        public Customer Customer { get; set; }

      
    }
}

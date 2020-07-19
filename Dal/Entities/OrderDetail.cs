using System;
using System.Collections.Generic;
using System.Text;

namespace Dal.Entities
{
   public  class OrderDetail
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public ICollection<Order> Orders { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}

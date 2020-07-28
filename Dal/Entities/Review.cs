using System;
using System.Collections.Generic;
using System.Text;

namespace Dal.Entities
{
    public class Review
    {
        public int Id { get; set; }
        public int Star { get; set; }
        public string Comment { get; set; }
        public DateTime CreateDate { get; set; }
        public int CustomerId { get; set; }
        public int ProductId { get; set; }
        public Customer Customer { get; set; }
        public Product Product { get; set; }

       
    }
}

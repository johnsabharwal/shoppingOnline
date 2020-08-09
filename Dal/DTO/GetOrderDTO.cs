using System;
using System.Collections.Generic;
using System.Text;

namespace Dal.DTO
{
    public class GetOrderDTO
    {
        public int CompanyId { get; set; }
        public int OrderId { get; set; }
        public int StatusId { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string OrderDate { get; set; }
        public string PaymentType { get; set; }
        public string OrderStatusType { get; set; }
        public int Total { get; internal set; }
        public string Product { get; internal set; }

    }
}

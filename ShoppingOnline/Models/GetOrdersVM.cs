using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ShoppingOnline.Models
{
    public class GetOrdersVM
    {
        public int CompanyId { get; set; }
        public IEnumerable<SelectListItem> OrderList { get; set; }
        public IEnumerable<SelectListItem> OrderStatus { get; set; }
        public int OrderId { get; set; }
        public int StatusId { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string OrderDate { get; set; }
        public string PaymentType { get; set; }
        public string OrderStatusType { get; set; }
        public int Total { get; internal set; }
    }
}
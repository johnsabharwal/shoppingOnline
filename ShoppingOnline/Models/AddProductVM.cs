using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ShoppingOnline.Models
{
    public class AddProductVM
    {
        public IEnumerable<SelectListItem> Category { get; set; }
        public int CategoryId { get; set; }
        public int SubCategoryId { get; set; }
        public IEnumerable<SelectListItem> SubCategory { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }

        public int Discount { get; set; }
        public string Quantity { get; set; }
        public string ImagePath { get; set; }
        public string Price { get; set; }
        public string Description { get; set; }
        public int CompanyId { get; set; }
        public int ProductId { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Dal.DTO
{
    public class AddProductDTO
    {
        public int CategoryId { get; set; }
        public int SubCategoryId { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public int Discount { get; set; }
        public string Quantity { get; set; }
        public string ImagePath { get; set; }
        public float Price { get; set; }
        public string Description { get; set; }
        public int CompanyId { get; set; }
        public int ProductId { get; set; }
    }
}

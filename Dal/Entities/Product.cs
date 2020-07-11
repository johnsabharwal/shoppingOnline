using System;
using System.Collections.Generic;
using System.Text;

namespace Dal.Entities
{
   public  class Product
    {
        public int Id { get; set; }
        public int SubCategoryId { get; set; }
        public string ImagePath { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public int Discount { get; set; }
        public float Price { get; set; }
        public string Description { get; set; }
        public string CompanyId { get; set; }
        public SubCategory SubCategory { get; set; }

        public Company Company { get; set; }

    }
}

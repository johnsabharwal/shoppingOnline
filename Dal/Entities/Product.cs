using System;
using System.Collections.Generic;
using System.Text;
using Dal.DTO;

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
        public int CompanyId { get; set; }
        public bool IsActive { get; set; }
        public SubCategory SubCategory { get; set; }
        public ICollection<Review> Reviews { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }
        public Company Company { get; set; }

        public static implicit operator Product(bool v)
        {
            throw new NotImplementedException();
        }
    }
}

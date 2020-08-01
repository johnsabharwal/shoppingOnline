using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using Remotion.Linq.Clauses;

namespace ShoppingOnline.Models
{
    public class AddProductVM
    {
        public IEnumerable<SelectListItem> Category { get; set; }

        public int CategoryId { get; set; }
        public int SubCategoryId { get; set; }
        public IEnumerable<SelectListItem> SubCategory { get; set; }
        [Required]
        [Display(Name = "Product Code")]

        public string ProductCode { get; set; }
        [Required]
        [Display(Name = "Product Name")]

        public string ProductName { get; set; }
        [Required]

        public string Discount { get; set; }
        public string Quantity { get; set; }
        [Required]
        [Display(Name = "Image")]

        public IFormFile ImagePath { get; set; }
        [Required]

        public string Price { get; set; }
        public string DiscountPrice { get; set; }
        [Required]

        public string Description { get; set; }
        [Required]

        public int CompanyId { get; set; }
        public int ProductId { get; set; }
        public string UploadPath { get; set; }

        public ReviewVM Reviews = new ReviewVM();
    }
}

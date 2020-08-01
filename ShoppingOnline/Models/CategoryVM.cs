using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingOnline.Models
{
    public class CategoryVM
    {
        public List<CategoryDetailDTO> CategoryDetails { get; set; }
    }

    public class CategoryDetailDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<SubCategory> SubCategory { get; set; }
    }
    public class SubCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}

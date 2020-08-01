using System;
using System.Collections.Generic;
using System.Text;

namespace Dal.DTO
{
    public class CategoryDTO
    {
        public CategoryDTO()
        {
            CategoryDetails=new List<CategoryDetailDTO>();
        }
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

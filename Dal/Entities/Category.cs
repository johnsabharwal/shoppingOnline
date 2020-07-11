using System;
using System.Collections.Generic;
using System.Text;

namespace Dal.Entities
{
   public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<SubCategory> SubCategory { get; set; }

    }
}

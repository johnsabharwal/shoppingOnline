using System;
using System.Collections.Generic;
using System.Text;

namespace Dal.Entities
{
   public class SubCategory
    {
        public int Id { get; set; }
        public int Name { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingOnline.Models
{
    public class GetProducts
    {
        public List<AddProductVM> products { get; set; }
        public int page { get; set; }
        public int total { get; set; }
    }
}

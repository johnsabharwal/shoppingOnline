using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dal.Entities;

namespace ShoppingOnline.Models
{
    public class BaseDataTable
    {
        public int draw { get; set; }
        public int recordsTotal { get; set; }
        public int recordsFiltered { get; set; }
        public dynamic data { get; set; }
    }
}

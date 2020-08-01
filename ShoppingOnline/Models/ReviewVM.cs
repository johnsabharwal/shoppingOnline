using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingOnline.Models
{
    public class ReviewVM
    {
        public double Stars { get; set; }
        public List<Comment> Comments { get; set; }
    }

    public class Comment
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string ReviewDetail { get; set; }
    }
}

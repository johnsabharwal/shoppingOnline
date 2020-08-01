using System;
using System.Collections.Generic;
using System.Text;

namespace Dal.DTO
{
    public class ReviewDto
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

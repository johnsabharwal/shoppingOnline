using System;
using System.Collections.Generic;
using System.Text;

namespace Dal.Entities
{
    public class TrackOrder
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public string TrackStatus { get; set; }
        public DateTime LastUpdate { get; set; }
        public Order Order { get; set; }

        
    }
}

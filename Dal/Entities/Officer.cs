using System;
using System.Collections.Generic;
using System.Text;

namespace Dal.Entities
{
    public class Officer
    {
        public int Id { get; set; }
        public string OfficerName { get; set; }
        public int DepartmentId { get; set; }
        public string ContactNumber { get; set; }
        public string EmailAddress { get; set; }
        public string Address { get; set; }
        public int CompanyId { get; set; }
        public Department Department { get; set; }
        public Company Company { get; set; }


    }
}

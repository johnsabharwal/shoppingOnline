using System;
using System.Collections.Generic;
using System.Text;

namespace Dal.DTO
{
    public class AddOfficerDTO
    {
        public string OfficerName { get; set; }
        public int DepartmentId { get; set; }
        public string ContactNumber { get; set; }
        public string Address { get; set; }
        public string EmailAddress { get; set; }
        public int OfficerId { get; set; }
        public int CompanyId { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Dal.DTO
{
    public class AddDepartmentDTO
    {
        public string DepartmentName { get; set; }
        public string OfficerInchargeName { get; set; }
        public string ContactNumber { get; set; }
        public string EmailAddress { get; set; }
        public int CompanyId { get; set; }
        public int DepartmentId { get; set; }
    }
}

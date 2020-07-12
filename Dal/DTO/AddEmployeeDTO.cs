using System;
using System.Collections.Generic;
using System.Text;

namespace Dal.DTO
{
   public class AddEmployeeDTO
    {
        public string EmployeeName { get; set; }
        public int DepartmentId { get; set; }
        public string ContactNumber { get; set; }
        public string Address { get; set; }
        public string EmailAddress { get; set; }
        public int CompanyId { get; set; }
        public int EmployeeId { get; set; }
    }
}

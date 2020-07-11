using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Text;

namespace Dal.Entities
{
    public class Department
    {
        public int Id { get; set; }
        public string DepartmentName { get; set; }
        public string OfficerInchargeName { get; set; }
        public string ContactNumber { get; set; }
        public string EmailAddress { get; set; }
        public int CompanyId { get; set; }
        public ICollection<Employee> Employee { get; set; }
        public ICollection<Officer> Officer { get; set; }
        public Company Company { get; set; }

    }
}

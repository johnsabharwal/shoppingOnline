using Dal.DTO;
using Dal.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dal.Interface
{
   public  interface ICustomerService
   {
       Customer GetCustomer(string emailId, string password);
       Customer RegisterCustomer(RegisterCustomerDTO dto);
    }
}

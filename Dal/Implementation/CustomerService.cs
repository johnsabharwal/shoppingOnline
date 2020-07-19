using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dal.DTO;
using Dal.Entities;
using Dal.Interface;

namespace Dal.Implementation
{
    public class CustomerService : ICustomerService
    {
        DBContext dBContext;
        public CustomerService(DBContext db)
        {
            dBContext = db;
        }
        public Customer GetCustomer(string emailId, string password)
        {
            return dBContext.Customers.FirstOrDefault(x => x.EmailId.Equals(emailId) && x.Password.Equals(password));
        }

        public Customer RegisterCustomer(RegisterCustomerDTO dto)
        {
            if (!dBContext.Customers.Any(x => x.EmailId.Equals(dto.EmailId)))
            {

                var customer = new Customer()
                {
                    EmailId = dto.EmailId,
                    Address = dto.Address,
                    ContactNumber = dto.Contact,
                    Password = dto.Password,
                    Name = dto.UserName,
                    CountryId = dto.CountryId,
                    StateId = dto.StateId,
                    Username = dto.UserName
                };
                dBContext.Customers.Add(customer);
                dBContext.SaveChanges();
                return customer;
            }
            else
            {
                return null;
            }
        }
    }
}

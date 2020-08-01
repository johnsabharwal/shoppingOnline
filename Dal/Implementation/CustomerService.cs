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
        private readonly IEmailSenderService _emailSenderService;
        public CustomerService(DBContext db,
            IEmailSenderService emailSenderService)
        {
            dBContext = db;
            _emailSenderService = emailSenderService;
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
                    Username = dto.UserName,
                    PinCode = dto.Pincode,
                    IsEmailVerified = false
                };
                dBContext.Customers.Add(customer);
                Random generator = new Random();
                String code = generator.Next(0, 999999).ToString("D6");
                dBContext.EmailVerification.Add(new EmailVerification()
                {
                    Code = code,
                    Email = dto.EmailId
                });
                dBContext.SaveChanges();
                var link = "https://localhost:44397/Account/VerifyEmail?email=" + dto.EmailId + "&code=" + code;
                if (_emailSenderService != null)
                {
                    _emailSenderService.SendEmail(dto.EmailId, dto.UserName, "Your are register successfully", link, "https://pbs.twimg.com/media/Ed0u4lSVoAAcPVN?format=png&name=small");
                }
                return customer;
            }
            else
            {
                return null;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dal.DTO;
using Dal.Entities;
using Dal.Interface;

namespace Dal.Implementation
{
    public class UserService : IUserService
    {
        DBContext dBContext;
        public UserService(DBContext db)
        {
            dBContext = db;
        }

        public bool CompanyLogin(string emailid, string password)
        {
           return dBContext.Companys.Any(x => x.EmailAddress.Equals(emailid) && x.Password == password);
        }

        public int CreateCompany(RegisterCompanyDTO registerCompanyDTO)
        {

            var company = new Company()
            {
                CountryId = registerCompanyDTO.CountryId,
                Name = registerCompanyDTO.Name,
                Address = registerCompanyDTO.Address,
                BusinessTypeId = registerCompanyDTO.BusinessTypeId,
                ContactNumber = registerCompanyDTO.Contact,
                EmailAddress = registerCompanyDTO.EmailId,
                OwnerName = registerCompanyDTO.CompanyName,
                Username = registerCompanyDTO.UserName,
                Password = registerCompanyDTO.Password
            };
            dBContext.Companys.Add(company);
            dBContext.SaveChanges();
            return company.Id;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using Dal.DTO;

namespace Dal.Interface
{
    public interface IUserService
    {
        int CreateCompany(RegisterCompanyDTO registerCompanyDTO);
        bool CompanyLogin(string emailid, string password);
    }
}

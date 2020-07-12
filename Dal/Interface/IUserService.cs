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
        void CreateAndUpdateDepartment(AddDepartmentDTO dto);
        void CreateAndUpdateOfficer(AddOfficerDTO dto);
        void CreateAndUpdateEmployee(AddEmployeeDTO dto);
        void CreateAndUpdateSuppplier(AddSupplierDTO dto);
        void CreateAndUpdatePromoter(AddPromotersDTO dto);
        void CreateAndUpdateProduct(AddProductDTO dto);
    }
}

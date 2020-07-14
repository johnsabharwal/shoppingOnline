using System;
using System.Collections.Generic;
using System.Text;
using Dal.DTO;
using Dal.Entities;

namespace Dal.Interface
{
    public interface IUserService
    {
        int CreateCompany(RegisterCompanyDTO registerCompanyDTO);
        int CompanyLogin(string emailid, string password);
        void CreateAndUpdateDepartment(AddDepartmentDTO dto);
        void CreateAndUpdateOfficer(AddOfficerDTO dto);
        void CreateAndUpdateEmployee(AddEmployeeDTO dto);
        void CreateAndUpdateSuppplier(AddSupplierDTO dto);
        void CreateAndUpdatePromoter(AddPromotersDTO dto);
        void CreateAndUpdateProduct(AddProductDTO dto);
        IEnumerable<Department> GetDepartments(int companyId);
        IEnumerable<Officer> GetOfficers( int companyId);
        IEnumerable<Employee> GetEmployees(int companyId);
        IEnumerable<Supplier> GetSuppliers(int companyId);
        IEnumerable<Promoter> GetPromoters(int companyId);
        IEnumerable<Product> GetProducts( int companyId);
    }
}

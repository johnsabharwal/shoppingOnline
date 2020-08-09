using System;
using System.Collections.Generic;
using System.Text;
using Dal.DTO;
using Dal.Entities;

namespace Dal.Interface
{
    public interface IUserService
    {
        /// <summary>
        /// This will create company
        /// </summary>
        /// <param name="registerCompanyDTO"></param>
        /// <returns></returns>
        int CreateCompany(RegisterCompanyDTO registerCompanyDTO);
        Company CompanyLogin(string emailid, string password);
        void CreateAndUpdateDepartment(AddDepartmentDTO dto);
        void CreateAndUpdateOfficer(AddOfficerDTO dto);
        void CreateAndUpdateEmployee(AddEmployeeDTO dto);
        void CreateAndUpdateSuppplier(AddSupplierDTO dto);
        void CreateAndUpdatePromoter(AddPromotersDTO dto);
        void CreateAndUpdateProduct(AddProductDTO dto);
        IEnumerable<Department> GetDepartments(int companyId);
        IEnumerable<Officer> GetOfficers(int companyId);
        IEnumerable<Employee> GetEmployees(int companyId);
        IEnumerable<Supplier> GetSuppliers(int companyId);
        IEnumerable<Promoter> GetPromoters(int companyId);
        IEnumerable<Product> GetProducts(int companyId, string search, string filter,int sid);
        Product GetProductById(int id);
        IEnumerable<Product> GetProductByCategoryId(int subCategoryId);
        IEnumerable<Product> GetProductsByIds(List<string> pIds);
        Customer GetUserById(int userid);
        int PlaceOrder(PlaceOrderDTO dto, int userId);
        IEnumerable<GetOrderDTO> GetOrdersByCustomerId(int customerId);
        IEnumerable<int> GetOrdersId();
        IEnumerable<GetOrderDTO> GetOrders(int companyId);
        void UpdateOrder(int orderId, int statusId);
        bool SaveCard(int userId, string cardno, string expiry, string cvv);
        string TrackOrder(int orderId);
        ReviewDto GetProductReview(int id);
        void GiveRating(int userId, int givenStar, string review, int productId);
        void DeleteProduct(int productId);
        Customer UpdateCustomer(RegisterCustomerDTO dto);
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using Dal.DTO;
using Dal.Entities;
using SubCategory = Dal.Entities.SubCategory;

namespace Dal.Interface
{
    public interface IMasterDataService
    {
        IEnumerable<Country> GetCountries();
        IEnumerable<BusinessType> GetBusinessTypes();

        IEnumerable<Department> GetDepartments( int companyId);
        IEnumerable<SubCategory> GetSubCategory( int categoryId);
        IEnumerable<Category> GetCategory();
        IEnumerable<State> GetStates( int countryId);
        IEnumerable<OrderStatus> GetOrderStatus();
        CategoryDTO GetAllCategories();
    }
}

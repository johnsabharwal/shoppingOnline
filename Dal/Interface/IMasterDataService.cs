using System;
using System.Collections.Generic;
using System.Text;
using Dal.Entities;

namespace Dal.Interface
{
    public interface IMasterDataService
    {
        IEnumerable<Country> GetCountries();
        IEnumerable<BusinessType> GetBusinessTypes();

        IEnumerable<Department> GetDepartments( int companyId);
        IEnumerable<SubCategory> GetSubCategory( int categoryId);
        IEnumerable<Category> GetCategory();
    }
}

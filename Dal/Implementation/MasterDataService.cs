using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dal.Entities;
using Dal.Interface;
using Dal.Migrations;

namespace Dal.Implementation
{
    public class MasterDataService : IMasterDataService
    {
        private DBContext _dbContext;
        public MasterDataService(DBContext db)
        {
            _dbContext = db;
        }
        public IEnumerable<Country> GetCountries()
        {
           return _dbContext.Countrys.ToList();
        }

        public IEnumerable<BusinessType> GetBusinessTypes()
        {
            return _dbContext.BusinessTypes.ToList();

        }

        public IEnumerable<Department> GetDepartments( int companyId)
        {
            return _dbContext.Departments.Where(x => x.CompanyId.Equals(companyId)).ToList();
        }

        public IEnumerable<SubCategory> GetSubCategory(int categoryId)
        {
            return _dbContext.SubCategory.Where(x => x.CategoryId == categoryId);
        }

        public IEnumerable<Category> GetCategory()
        {
          return  _dbContext.Category.ToList();
        }

        public IEnumerable<State> GetStates(int countryId)
        {
            return _dbContext.States.Where(x => x.CountryId == countryId);
        }
    }
}

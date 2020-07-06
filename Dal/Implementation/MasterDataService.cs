using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dal.Entities;
using Dal.Interface;

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
    }
}

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Dal.Entities;

namespace Dal
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options) { }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Company> Companys { get; set; }
        public DbSet<Country> Countrys { get; set; }
        public DbSet<BusinessType> BusinessTypes { get; set; }
    }
}

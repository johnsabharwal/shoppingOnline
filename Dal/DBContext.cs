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
        public DbSet<Category> Category { get; set; }
        public DbSet<SubCategory> SubCategory { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Officer> Officers { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Promoter> Promoters { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<OrderStatus> OrderStatus { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<EmailVerification> EmailVerification { get; set; }
        public DbSet<CardDetails> CardDetails { get; set; }

    }
}

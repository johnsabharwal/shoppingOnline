using System.Collections.Generic;
using System.Linq;
using Dal;
using Dal.DTO;
using Dal.Entities;
using Dal.Enum;
using Dal.Implementation;
using Dal.Interface;
using Microsoft.EntityFrameworkCore.Internal;
using Moq;
using Newtonsoft.Json;
using Services.Tests.Fixtures;
using StructureMap;
using Xunit;

namespace Services.Tests
{
    public class UnitTest : IClassFixture<DatabaseFixture>, IClassFixture<ContainerFixture>
    {
        private readonly DBContext _dbContext;
        public IContainer _container;
        private static bool isConfigured = false;
        public List<CartDesc> cart = new List<CartDesc>();

        public UnitTest(DatabaseFixture databaseFixture,
            ContainerFixture containerFixture)
        {
            _dbContext = databaseFixture.DbContext;
            _container = containerFixture.Container;
            if (!isConfigured)
            {
                isConfigured = true;
                var emailSenderService = new Mock<IEmailSenderService>();
                _container.Configure(x => x.For<IEmailSenderService>().Use(emailSenderService.Object));
            }
        }

        [Fact]
        public void Company_Login()
        {

            _dbContext.Companys.Add(new Company()
            {
                Name = "George",
                Address = "24,Black street",
                ContactNumber = "9803482335",
                OwnerName = "George",
                Password = "123456",
                EmailAddress = "George@yahoo.com"
            });
            _dbContext.SaveChanges();
            var userService = new UserService(_dbContext,null);
            var data = userService.CompanyLogin("George@yahoo.com", "123456");
            Assert.NotNull(data);
            Assert.Equal("George", data.Name);
        }
        [Fact]
        public void Company_Register()
        {
            var userService = new UserService(_dbContext, null);
            var data = userService.CreateCompany(new RegisterCompanyDTO()
            {
                Name = "mark",
                Address = "24,Black street",
                Contact = "9803482335",
                UserName = "mark",
                Password = "123456",
                EmailId = "mark@yahoo.com"
            });
            Assert.True(data > 0);
        }
        [Fact]
        public void Customer_Login()
        {

            _dbContext.Customers.Add(new Customer()
            {
                Name = "peter",
                Address = "24,Black street",
                ContactNumber = "9803482335",
                Password = "123456",
                EmailId = "peter@yahoo.com"
            });
            _dbContext.SaveChanges();
            var userService = new CustomerService(_dbContext,null);
            var data = userService.GetCustomer("peter@yahoo.com", "123456");
            Assert.NotNull(data);
            Assert.Equal("peter", data.Name);
        }
        [Fact]
        public void Customer_Register()
        {
            var userService = new CustomerService(_dbContext, null);
            var data = userService.RegisterCustomer(new RegisterCustomerDTO()
            {
                UserName = "Andres",
                Address = "24,Black street",
                Contact = "9803482335",
                Password = "123456",
                EmailId = "Andres@yahoo.com"
            });
            Assert.NotNull(data);
        }
        [Fact]
        public void Search_Product()
        {

            _dbContext.Products.Add(new Product()
            {
                ProductName = "iphone 11",
                CompanyId = 1,
                Price = 500,
                SubCategoryId = 1
            });
            _dbContext.SaveChanges();
            var userService = new UserService(_dbContext,null);
            var data = userService.GetProducts(0, "iphone", "",0);
            Assert.NotNull(data);
            Assert.Contains(data.ToList(), x => x.ProductName.Contains("iphone"));
        }
        [Fact]
        public void Add_To_Cart()
        {

            cart.Add(new CartDesc()
            {
                Quantity = 1,
                ProductId = 1
            });
            Assert.Contains(cart.ToList(), x => x.ProductId.Equals(1));
        }
        [Fact]
        public void Place_Order()
        {

            cart.Add(new CartDesc()
            {
                Quantity = 1,
                ProductId = 1
            });
            var userService = new UserService(_dbContext, null);
            var data = userService.PlaceOrder(new PlaceOrderDTO()
            {
                PaymentType = "COD",
                Total = 500,
                Cart = JsonConvert.SerializeObject(cart)
            }, 1);
            Assert.True(data > 0);
        }
        [Fact]
        public void Add_Payment_Method()
        {

            var userService = new UserService(_dbContext, null);
            var result = userService.SaveCard(1, "15151515125254848", "may/2024", "123");
            Assert.True(result);
        }
        [Fact]
        public void Track_Order()
        {
            cart.Add(new CartDesc()
            {
                Quantity = 1,
                ProductId = 1
            });
            var userService = new UserService(_dbContext, null);
            var data = userService.PlaceOrder(new PlaceOrderDTO()
            {
                PaymentType = "COD",
                Total = 500,
                Cart = JsonConvert.SerializeObject(cart)
            }, 1);
            var result = userService.TrackOrder(1);
            Assert.Equal(EnumOrderStatus.WaitingForConfirmation.ToString(), result);
        }
        [Fact]
        public void Add_And_Get_Officers()
        {

            var userService = new UserService(_dbContext, null);
            userService.CreateAndUpdateOfficer(new AddOfficerDTO()
            {
                DepartmentId = 1,
                ContactNumber = "89595626226",
                CompanyId = 1,
                Address = "Canada",
                EmailAddress = "user@yahoo.in",
                OfficerName = "Michael"
            });
            var result = userService.GetOfficers(1);
            Assert.True(result.ToList().Any());
            Assert.Contains(result.ToList(), x => x.OfficerName.Contains("Michael"));

        }
        [Fact]
        public void Add_And_Get_Product()
        {

            var userService = new UserService(_dbContext, null);
            userService.CreateAndUpdateProduct(new AddProductDTO()
            {
                ProductName = "Samsung note 10",
                CompanyId = 1,
                Discount = 5,
                Price = 500,
                SubCategoryId = 1
            });
            var result = userService.GetProducts(1, "", "",0);
            Assert.True(result.ToList().Any());
            Assert.Contains(result.ToList(), x => x.ProductName.Contains("Samsung"));
        }
        [Fact]
        public void Add_And_Get_Employees()
        {

            var userService = new UserService(_dbContext, null);
            userService.CreateAndUpdateEmployee(new AddEmployeeDTO()
            {
                DepartmentId = 1,
                ContactNumber = "89595626226",
                CompanyId = 1,
                Address = "Canada",
                EmailAddress = "John@yahoo.in",
                EmployeeName = "John"
            });
            var result = userService.GetEmployees(1);
            Assert.True(result.ToList().Any());
            Assert.Contains(result.ToList(), x => x.EmployeeName.Contains("John"));
        }
        [Fact]
        public void Add_And_Get_Suppliers()
        {

            var userService = new UserService(_dbContext, null);
            userService.CreateAndUpdateSuppplier(new AddSupplierDTO()
            {
                ContactNumber = "89595626226",
                CompanyId = 1,
                Address = "Canada",
                EmailAddress = "Sean@yahoo.in",
                SupplierName = "Sean"
            });
            var result = userService.GetSuppliers(1);
            Assert.True(result.ToList().Any());
            Assert.Contains(result.ToList(), x => x.SupplierName.Contains("Sean"));
        }
        [Fact]
        public void Add_And_Get_Departments()
        {

            var userService = new UserService(_dbContext, null);
            userService.CreateAndUpdateDepartment(new AddDepartmentDTO()
            {
                ContactNumber = "89595626226",
                CompanyId = 1,
                EmailAddress = "Account@yahoo.in",
                DepartmentName = "Account"
            });
            var result = userService.GetDepartments(1);
            Assert.True(result.ToList().Any());
            Assert.Contains(result.ToList(), x => x.DepartmentName.Contains("Account"));
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dal.DTO;
using Dal.Entities;
using Dal.Enum;
using Dal.Interface;
using Newtonsoft.Json;

namespace Dal.Implementation
{
    public class UserService : IUserService
    {
        DBContext dBContext;
        public UserService(DBContext db)
        {
            dBContext = db;
        }

        public int CompanyLogin(string emailid, string password)
        {
            return dBContext.Companys.FirstOrDefault(x => x.EmailAddress.Equals(emailid) && x.Password == password)?.Id ?? 0;
        }

        public void CreateAndUpdateDepartment(AddDepartmentDTO dto)
        {
            if (dto.DepartmentId != 0)
            {

                var department = dBContext.Departments.FirstOrDefault(x => x.Id == dto.DepartmentId);
                if (department != null)
                {
                    department.CompanyId = dto.CompanyId;
                    department.ContactNumber = dto.ContactNumber;
                    department.DepartmentName = dto.DepartmentName;
                    department.EmailAddress = dto.EmailAddress;
                    department.OfficerInchargeName = dto.OfficerInchargeName;
                    dBContext.SaveChanges();
                }
            }
            else
            {
                var department = new Department()
                {
                    CompanyId = dto.CompanyId,
                    ContactNumber = dto.ContactNumber,
                    DepartmentName = dto.DepartmentName,
                    EmailAddress = dto.EmailAddress,
                    OfficerInchargeName = dto.OfficerInchargeName,
                };
                dBContext.Departments.Add(department);
                dBContext.SaveChanges();
            }
        }

        public void CreateAndUpdateOfficer(AddOfficerDTO dto)
        {
            if (dto.OfficerId != 0)
            {

                var officer = dBContext.Officers.FirstOrDefault(x => x.Id == dto.OfficerId);
                if (officer != null)
                {
                    officer.CompanyId = dto.CompanyId;
                    officer.ContactNumber = dto.ContactNumber;
                    officer.Address = dto.Address;
                    officer.EmailAddress = dto.EmailAddress;
                    officer.DepartmentId = dto.DepartmentId;
                    officer.OfficerName = dto.OfficerName;
                    dBContext.SaveChanges();
                }
            }
            else
            {
                var officer = new Officer()
                {
                    CompanyId = dto.CompanyId,
                    ContactNumber = dto.ContactNumber,
                    Address = dto.Address,
                    EmailAddress = dto.EmailAddress,
                    DepartmentId = dto.DepartmentId,
                    OfficerName = dto.OfficerName
                };
                dBContext.Officers.Add(officer);
                dBContext.SaveChanges();
            }
        }

        public void CreateAndUpdateEmployee(AddEmployeeDTO dto)
        {
            if (dto.EmployeeId != 0)
            {

                var employee = dBContext.Employees.FirstOrDefault(x => x.Id == dto.EmployeeId);
                if (employee != null)
                {
                    employee.CompanyId = dto.CompanyId;
                    employee.ContactNumber = dto.ContactNumber;
                    employee.Address = dto.Address;
                    employee.EmailAddress = dto.EmailAddress;
                    employee.DepartmentId = dto.DepartmentId;
                    employee.EmployeeName = dto.EmployeeName;
                    dBContext.SaveChanges();
                }
            }
            else
            {
                var employee = new Employee()
                {
                    CompanyId = dto.CompanyId,
                    ContactNumber = dto.ContactNumber,
                    Address = dto.Address,
                    EmailAddress = dto.EmailAddress,
                    DepartmentId = dto.DepartmentId,
                    EmployeeName = dto.EmployeeName
                };
                dBContext.Employees.Add(employee);
                dBContext.SaveChanges();
            }
        }

        public void CreateAndUpdateSuppplier(AddSupplierDTO dto)
        {
            if (dto.SupplierId != 0)
            {

                var supplier = dBContext.Suppliers.FirstOrDefault(x => x.Id == dto.SupplierId);
                if (supplier != null)
                {
                    supplier.CompanyId = dto.CompanyId;
                    supplier.ContactNumber = dto.ContactNumber;
                    supplier.Address = dto.Address;
                    supplier.EmailAddress = dto.EmailAddress;
                    supplier.SupplierName = dto.SupplierName;
                    dBContext.SaveChanges();
                }
            }
            else
            {
                var supplier = new Supplier()
                {
                    CompanyId = dto.CompanyId,
                    ContactNumber = dto.ContactNumber,
                    Address = dto.Address,
                    EmailAddress = dto.EmailAddress,
                    SupplierName = dto.SupplierName
                };
                dBContext.Suppliers.Add(supplier);
                dBContext.SaveChanges();
            }
        }

        public void CreateAndUpdatePromoter(AddPromotersDTO dto)
        {
            if (dto.PromoterId != 0)
            {

                var promoter = dBContext.Promoters.FirstOrDefault(x => x.Id == dto.PromoterId);
                if (promoter != null)
                {
                    promoter.CompanyId = dto.CompanyId;
                    promoter.ContactNumber = dto.ContactNumber;
                    promoter.Address = dto.Address;
                    promoter.EmailAddress = dto.EmailAddress;
                    promoter.PromoterName = dto.PromoterName;
                    dBContext.SaveChanges();
                }
            }
            else
            {
                var promoter = new Promoter()
                {
                    CompanyId = dto.CompanyId,
                    ContactNumber = dto.ContactNumber,
                    Address = dto.Address,
                    EmailAddress = dto.EmailAddress,
                    PromoterName = dto.PromoterName
                };
                dBContext.Promoters.Add(promoter);
                dBContext.SaveChanges();
            }
        }

        public void CreateAndUpdateProduct(AddProductDTO dto)
        {
            if (dto.ProductId != 0)
            {

                var product = dBContext.Products.FirstOrDefault(x => x.Id == dto.ProductId);
                if (product != null)
                {
                    product.CompanyId = dto.CompanyId;
                    product.SubCategoryId = dto.SubCategoryId;
                    product.Description = dto.Description;
                    product.Discount = dto.Discount;
                    product.Price = dto.Price;
                    product.ProductCode = dto.ProductCode;
                    product.ProductName = dto.ProductName;
                    product.ImagePath = dto.ImagePath;
                    dBContext.SaveChanges();
                }
            }
            else
            {
                var product = new Product()
                {
                    CompanyId = dto.CompanyId,
                    SubCategoryId = dto.SubCategoryId,
                    Description = dto.Description,
                    Discount = dto.Discount,
                    Price = dto.Price,
                    ProductCode = dto.ProductCode,
                    ProductName = dto.ProductName,
                    ImagePath = dto.ImagePath,
                };
                dBContext.Products.Add(product);
                dBContext.SaveChanges();
            }
        }

        public IEnumerable<Department> GetDepartments(int companyId)
        {
            return dBContext.Departments.Where(x => x.CompanyId == companyId);
        }

        public IEnumerable<Officer> GetOfficers(int companyId)
        {
            return dBContext.Officers.Where(x => x.CompanyId == companyId);
        }
        public IEnumerable<Employee> GetEmployees(int companyId)
        {
            return dBContext.Employees.Where(x => x.CompanyId == companyId);
        }

        public IEnumerable<Supplier> GetSuppliers(int companyId)
        {
            return dBContext.Suppliers.Where(x => x.CompanyId == companyId);
        }
        public IEnumerable<Promoter> GetPromoters(int companyId)
        {
            return dBContext.Promoters.Where(x => x.CompanyId == companyId);
        }
        public int CreateCompany(RegisterCompanyDTO registerCompanyDTO)
        {

            var company = new Company()
            {
                CountryId = registerCompanyDTO.CountryId,
                Name = registerCompanyDTO.Name,
                Address = registerCompanyDTO.Address,
                BusinessTypeId = registerCompanyDTO.BusinessTypeId,
                ContactNumber = registerCompanyDTO.Contact,
                EmailAddress = registerCompanyDTO.EmailId,
                OwnerName = registerCompanyDTO.CompanyName,
                Username = registerCompanyDTO.UserName,
                Password = registerCompanyDTO.Password
            };
            dBContext.Companys.Add(company);
            dBContext.SaveChanges();
            return company.Id;
        }

        public IEnumerable<Product> GetProducts(int companyId)
        {
            if (companyId == 0)
            {
                return dBContext.Products;
            }
            else
            {
                return dBContext.Products.Where(x => x.CompanyId == companyId);
            }
        }

        public Product GetProductById(int id)
        {
            return dBContext.Products.Single(x => x.Id == id);
        }

        public IEnumerable<Product> GetProductByCategoryId(int subCategoryId)
        {
            return dBContext.Products.Where(x => x.SubCategoryId == subCategoryId).Distinct().Take(4);
        }

        public IEnumerable<Product> GetProductsByIds(List<string> pIds)
        {
            return dBContext.Products.Where(x => pIds.Contains(x.Id.ToString()));
        }

        public Customer GetUserById(int userid)
        {
            return dBContext.Customers.FirstOrDefault(x => x.Id == userid);
        }

        public int PlaceOrder(PlaceOrderDTO dto, int userid)
        {
            var cart = JsonConvert.DeserializeObject<List<CartDesc>>(dto.Cart);
            var order = new Order()
            {
                CustomerId = userid,
                OrderDate = DateTime.Now,
                PaymentType = dto.PaymentType,
                Total = dto.Total,
                OrderStatusId = (int)EnumOrderStatus.WaitingForConfirmation,
            };
            dBContext.Orders.Add(order);
            dBContext.SaveChanges();
            foreach (var item in cart)
            {
                dBContext.OrderDetails.Add(new OrderDetail()
                {
                    OrderId = order.Id,
                    ProductId = item.ProductId,
                    Quantity = item.Quantity
                });
            }
            dBContext.SaveChanges();
            return order.Id;

        }

        public IEnumerable<int> GetOrdersId()
        {
            return dBContext.Orders.Select(x => x.Id).ToList();
        }

        public IEnumerable<GetOrderDTO> GetOrders(int companyId)
        {
            var productsIds = dBContext.Products.Where(x => x.CompanyId.Equals(companyId)).Select(y => y.Id).Distinct().ToList();
            var orderIds = dBContext.OrderDetails.Where(x => productsIds.Contains(x.ProductId)).Select(y => y.OrderId).Distinct().ToList();
            var result = from order in dBContext.Orders
                         //join detail in dBContext.OrderDetails on order.Id equals detail.OrderId
                         //join detail in dBContext.OrderDetails on order.Id equals detail.OrderId
                         join customer in dBContext.Customers on order.CustomerId equals customer.Id
                         join status in dBContext.OrderStatus on order.OrderStatusId equals status.Id
                         where orderIds.Contains(order.Id)
                         select new
                         {
                             order = order,
                             customer = customer,
                             //details = detail,
                             status = status,
                         };
            //var result = dBContext.Orders
            //    .Join(dBContext.OrderDetails, order => order.Id, detail => detail.OrderId,
            //        (order, detail) => new { order, detail })
            //    .Join(dBContext.Customers, @t => @t.order.CustomerId, customer => customer.Id,
            //        (@t, customer) => new { @t, customer })
            //    .Where(@t => orderIds.Contains(@t.@t.order.Id))
            //    .Select(@t => new { order = @t.@t, });
            return result.Select(x => new GetOrderDTO()
            {
                OrderId = x.order.Id,
                OrderStatusType = x.status.Name,
                CustomerId = x.customer.Id,
                OrderDate = x.order.OrderDate.ToShortDateString(),
                PaymentType = x.order.PaymentType,
                CustomerName = x.customer.Name,
                Total = x.order.Total
            }).ToList();
        }

        public void UpdateOrder(int orderId, int statusId)
        {
            var order = dBContext.Orders.FirstOrDefault(x => x.Id == orderId);
            order.OrderStatusId = statusId;
            dBContext.SaveChanges();
        }
    }
}

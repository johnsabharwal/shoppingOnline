using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Dal.Interface;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using ShoppingOnline.Models;

namespace ShoppingOnline.Controllers
{
    public class GetCompanyDataController : Controller
    {
        private readonly IUserService _userService;

        public GetCompanyDataController(IUserService userService)
        {
            _userService = userService;
        }
        public IActionResult GetDepartments(int draw, int companyId, int start, int length)
        {
            Models.BaseDataTable dataTable = new Models.BaseDataTable();
            var result = _userService.GetDepartments(companyId);
            dataTable.draw = draw;
            dataTable.data = result.Select(x => new AddDepartmentVM()
            {
                DepartmentId = x.Id,
                DepartmentName = x.DepartmentName,
                ContactNumber = x.ContactNumber,
                EmailAddress = x.EmailAddress,
                OfficerInchargeName = x.OfficerInchargeName,

            }).ToList().Skip(start).Take(length);
            dataTable.recordsTotal = result.Count();
            dataTable.recordsFiltered = result.Count();
            return Json(dataTable);

        }
        public IActionResult GetOfficers(int draw, int companyId, int start, int length)
        {
            Models.BaseDataTable dataTable = new Models.BaseDataTable();
            var result = _userService.GetOfficers(companyId);
            dataTable.draw = draw;
            dataTable.data = result.Select(x => new AddOfficerVM()
            {
                DepartmentId = x.Id,
                OfficerName = x.OfficerName,
                ContactNumber = x.ContactNumber,
                EmailAddress = x.EmailAddress,
                Address = x.Address,
                OfficerId = x.Id

            }).ToList().Skip(start).Take(length);
            dataTable.recordsTotal = result.Count();
            dataTable.recordsFiltered = result.Count();
            return Json(dataTable);
        }
        public IActionResult GetEmployees(int draw, int companyId, int start, int length)
        {
            Models.BaseDataTable dataTable = new Models.BaseDataTable();
            var result = _userService.GetEmployees(companyId);
            dataTable.draw = draw;
            dataTable.data = result.Select(x => new AddEmployeeVM()
            {
                DepartmentId = x.Id,
                EmployeeName = x.EmployeeName,
                ContactNumber = x.ContactNumber,
                EmailAddress = x.EmailAddress,
                Address = x.Address,
                EmployeeId = x.Id
            }).ToList().Skip(start).Take(length);
            dataTable.recordsTotal = result.Count();
            dataTable.recordsFiltered = result.Count();
            return Json(dataTable);
        }
        public IActionResult GetSuppliers(int draw, int companyId, int start, int length)
        {
            Models.BaseDataTable dataTable = new Models.BaseDataTable();
            var result = _userService.GetSuppliers(companyId);
            dataTable.draw = draw;
            dataTable.data = result.Select(x => new AddSuppliersVM()
            {
                SupplierName = x.SupplierName,
                ContactNumber = x.ContactNumber,
                EmailAddress = x.EmailAddress,
                Address = x.Address,
                SupplierId = x.Id

            }).ToList().Skip(start).Take(length);
            dataTable.recordsTotal = result.Count();
            dataTable.recordsFiltered = result.Count();
            return Json(dataTable);
        }
        public IActionResult GetPromoters(int draw, int companyId, int start, int length)
        {
            Models.BaseDataTable dataTable = new Models.BaseDataTable();
            var result = _userService.GetPromoters(companyId);
            dataTable.draw = draw;
            dataTable.data = result.Select(x => new AddPromotersVM()
            {
                PromoterName = x.PromoterName,
                ContactNumber = x.ContactNumber,
                EmailAddress = x.EmailAddress,
                Address = x.Address,
                PromoterId = x.Id

            }).ToList().Skip(start).Take(length);
            dataTable.recordsTotal = result.Count();
            dataTable.recordsFiltered = result.Count();
            return Json(dataTable);
        }
        public IActionResult GetProducts(int draw, int companyId, int start, int length)
        {
            Models.BaseDataTable dataTable = new Models.BaseDataTable();
            var result = _userService.GetProducts(companyId,"","",0);
            dataTable.draw = draw;
            dataTable.data = result.Select(x => new AddProductVM()
            {
                ProductName = x.ProductName,
                ProductCode = x.ProductCode,
                Discount = x.Discount.ToString(),
                Price = x.Price.ToString(),
                Description = x.Description,
                UploadPath = "/images/" + x.ImagePath,
                SubCategoryId = x.SubCategoryId,
                ProductId = x.Id
            }).ToList().Skip(start).Take(length);
            dataTable.recordsTotal = result.Count();
            dataTable.recordsFiltered = result.Count();
            return Json(dataTable);
        }
        public IActionResult GetOrders(int draw, int companyId, int start, int length)
        {
            Models.BaseDataTable dataTable = new Models.BaseDataTable();
            var result = _userService.GetOrders(companyId);
            dataTable.draw = draw;
            dataTable.data = result.Select(x => new GetOrdersVM()
            {
                OrderId = x.OrderId,
                OrderStatusType = x.OrderStatusType,
                CustomerId = x.CustomerId,
                OrderDate = x.OrderDate,
                PaymentType = x.PaymentType,
                CustomerName = x.CustomerName,
                Total = x.Total
            }).ToList().Skip(start).Take(length);
            dataTable.recordsTotal = result.Count();
            dataTable.recordsFiltered = result.Count();
            return Json(dataTable);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dal.Interface;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ShoppingOnline.Models;

namespace ShoppingOnline.Controllers
{
    public class CustomerController : BaseController
    {
        private readonly IUserService _userService;
        private readonly IMasterDataService _masterDataService;

        public CustomerController(IUserService userService,
            IMasterDataService masterDataService )
        {
            base._masterDataService = masterDataService;
            _masterDataService = masterDataService;
            _userService = userService;
        }
        public IActionResult Index(int customerId)
        {
            ViewBag.menu = JsonConvert.SerializeObject(GetCategory());

            ViewBag.customerId = customerId;
            return View();
        }
        public IActionResult Profile(int customerId)
        {
            ViewBag.menu = JsonConvert.SerializeObject(GetCategory());

            ViewBag.customerId = customerId;
            return View();
        }
        public IActionResult Orders(int customerId)
        {
            ViewBag.menu = JsonConvert.SerializeObject(GetCategory());

            ViewBag.customerId = customerId;
            return View();
        }
        public IActionResult Wishlist(int customerId)
        {
            ViewBag.menu = JsonConvert.SerializeObject(GetCategory());

            ViewBag.customerId = customerId;
            return View();
        }

        public IActionResult GetOrders(int draw, int customerId, int start, int length)
        {
            Models.BaseDataTable dataTable = new Models.BaseDataTable();
            var result = _userService.GetOrdersByCustomerId(customerId);
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
            ViewBag.menu = JsonConvert.SerializeObject(GetCategory());

            return Json(dataTable);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Dal.DTO;
using Dal.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using ShoppingOnline.Models;

namespace ShoppingOnline.Controllers
{
    public class CustomerController : BaseController
    {
        private readonly IUserService _userService;
        private readonly IMasterDataService _masterDataService;


        public CustomerController(IUserService userService,
            IMasterDataService masterDataService)
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
            UpdateCustomerVM vm = new UpdateCustomerVM();
            ViewBag.customerId = customerId;
            var user = _userService.GetUserById(customerId);
            vm.UserName = user.Name;
            vm.EmailId = user.EmailId;
            vm.Address = user.Address;
            vm.Contact = user.ContactNumber;
            vm.CountryId = user.CountryId;
            vm.StateId = user.StateId;
            vm.Id = user.Id;
            vm.Pincode = user.PinCode;
            vm.CountryList = _masterDataService.GetCountries().Select(x => new SelectListItem()
            {
                Text = x.Name,
                Value = x.Id.ToString()
            }).ToList();
            vm.StateList = _masterDataService.GetStates(user.CountryId).Select(x => new SelectListItem()
            {
                Text = x.Name,
                Value = x.Id.ToString()
            }).ToList();
            ViewBag.customerId = customerId;

            return View(vm);
        }
        public IActionResult UserRegister(UpdateCustomerVM registerCustomer)
        {
            if (!ModelState.IsValid)
            {
                ShowToaster("Please fill required fields", ToasterLevel.Danger);
                return RedirectToAction("Profile", new { customerId = registerCustomer.Id });
            }
            ViewBag.Class = "inner-page";
            var config = new MapperConfiguration(cfg => cfg.CreateMap<UpdateCustomerVM, RegisterCustomerDTO>());
            var mapper = new Mapper(config);
            RegisterCustomerDTO dto = mapper.DefaultContext.Mapper.Map<RegisterCustomerDTO>(registerCustomer);
            var customer = _userService.UpdateCustomer(dto);
            if (customer != null)
            {
                TempData["isLogin"] = 1;
                TempData["uid"] = customer.Id;
                TempData["uname"] = customer.Name;
                ShowToaster("Profile updated successfully", ToasterLevel.Success);
                return RedirectToAction("Profile", new { customerId = registerCustomer.Id });
            }
            else
            {
                ShowToaster("Profile not updated", ToasterLevel.Danger);
                return RedirectToAction("Profile", new { customerId = registerCustomer.Id });
            }

        }
        public IActionResult Orders(int customerId)
        {
            ViewBag.menu = JsonConvert.SerializeObject(GetCategory());

            ViewBag.customerId = customerId;
            return View();
        }
        public IActionResult TrackOrders(int customerId)
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

        public JsonResult GetOrders(int customerId, int orderId = 0)
        {
            return Json(_userService.GetOrdersByCustomerId(customerId, orderId));
        }
    }
}

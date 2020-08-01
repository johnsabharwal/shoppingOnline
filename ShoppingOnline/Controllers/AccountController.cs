using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
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
    public class AccountController : BaseController
    {
        private readonly ICustomerService _customerService;
        private readonly IMasterDataService _masterDataService;


        public AccountController(ICustomerService customerService,
            IMasterDataService masterDataService)
        {
            base._masterDataService = masterDataService;
            _customerService = customerService;
            _masterDataService = masterDataService;
        }

        public IActionResult Login()
        {
            ViewBag.menu = JsonConvert.SerializeObject(GetCategory());

            return View();
        }
        public IActionResult UserLogin(string emailId, string password)
        {
            if (string.IsNullOrEmpty(emailId) || string.IsNullOrEmpty(password))
            {
                ShowToaster("Please fill required fields", ToasterLevel.Danger);
                return RedirectToAction("Login", "Account");
            }
            ViewBag.Class = "inner-page";
            var customer = _customerService.GetCustomer(emailId, password);
            if (customer != null)
            {
                TempData["isLogin"] = 1;
                TempData["uid"] = customer.Id;
                TempData["uname"] = customer.Name;
                ShowToaster("Welcome", ToasterLevel.Success);
                return RedirectToAction("index", "home");

            }
            else
            {
                ShowToaster("Invalid Username/password", ToasterLevel.Danger);
                return RedirectToAction("Login", "Account");

            }
        }
        public IActionResult Register()
        {
            RegisterCustomerVM registerCustomerVM = new RegisterCustomerVM();
            ViewBag.Class = "inner-page";
            registerCustomerVM.CountryList = _masterDataService.GetCountries().Select(x => new SelectListItem()
            {
                Text = x.Name,
                Value = x.Id.ToString()
            }).ToList();
            ViewBag.menu = JsonConvert.SerializeObject(GetCategory());
            return View(registerCustomerVM);
        }

        public IActionResult UserRegister(RegisterCustomerVM registerCustomer)
        {
            if (!ModelState.IsValid)
            {
                ShowToaster("Please fill required fields", ToasterLevel.Danger);
                return RedirectToAction("Register", "Account");
            }
            ViewBag.Class = "inner-page";
            var config = new MapperConfiguration(cfg => cfg.CreateMap<RegisterCustomerVM, RegisterCustomerDTO>());
            var mapper = new Mapper(config);
            RegisterCustomerDTO dto = mapper.DefaultContext.Mapper.Map<RegisterCustomerDTO>(registerCustomer);
            var customer = _customerService.RegisterCustomer(dto);
            if (customer != null)
            {
                TempData["isLogin"] = 1;
                TempData["uid"] = customer.Id;
                TempData["uname"] = customer.Name;
                ShowToaster("User register successfully", ToasterLevel.Success);
                return RedirectToAction("index", "home");
            }
            else
            {
                ShowToaster("Email id already exists", ToasterLevel.Danger);
                return RedirectToAction("Register", "Account");
            }

        }
    }
}

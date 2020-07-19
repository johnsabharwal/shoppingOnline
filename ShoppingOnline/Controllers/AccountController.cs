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
using ShoppingOnline.Models;

namespace ShoppingOnline.Controllers
{
    public class AccountController : Controller
    {
        private readonly ICustomerService _customerService;
        private readonly IMasterDataService _masterDataService;


        public AccountController(ICustomerService customerService,
            IMasterDataService masterDataService)
        {
            _customerService = customerService;
            _masterDataService = masterDataService;
        }

        public IActionResult Login()
        {
            return View();
        }
        public IActionResult UserLogin(string emailId, string password)
        {
            ViewBag.Class = "inner-page";
            var customer = _customerService.GetCustomer(emailId, password);
            if (customer != null)
            {
                TempData["isLogin"] = 1;
                TempData["uid"] = customer.Id;
                TempData["uname"] = customer.Name;
                return RedirectToAction("index", "home");

            }
            else
            {
                return RedirectToAction("Login", "Account");

            }
        }
        public IActionResult Register()
        {
            RegisterCustomerVM registerCustomerVM=new RegisterCustomerVM();
            ViewBag.Class = "inner-page";
            registerCustomerVM.CountryList = _masterDataService.GetCountries().Select(x => new SelectListItem()
            {
                Text = x.Name,
                Value = x.Id.ToString()
            }).ToList();
            return View(registerCustomerVM);
        }

        public IActionResult UserRegister(RegisterCustomerVM registerCustomer)
        {
            ViewBag.Class = "inner-page";
            var config = new MapperConfiguration(cfg => cfg.CreateMap<RegisterCustomerVM, RegisterCustomerDTO>());
            var mapper = new Mapper(config);
            RegisterCustomerDTO dto = mapper.Map<RegisterCustomerDTO>(registerCustomer);
            var customer = _customerService.RegisterCustomer(dto);
            if (customer != null)
            {
                TempData["isLogin"] = 1;
                TempData["uid"] = customer.Id;
                TempData["uname"]= customer.Name;
              return  RedirectToAction("index", "home");
            }
            else
            {
                return RedirectToAction("Register", "Account");
            }
           
        }
    }
}

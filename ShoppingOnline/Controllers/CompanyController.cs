using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Dal.DTO;
using Dal.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShoppingOnline.Models;

namespace ShoppingOnline.Controllers
{
    public class CompanyController : Controller
    {
        private readonly IUserService _userService;
        private readonly IMasterDataService _masterDataService;
        public CompanyController(IUserService userService,
            IMasterDataService masterDataService)
        {
            _userService = userService;
            _masterDataService = masterDataService;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult CompanyLogin()
        {
            return View();
        }
        public IActionResult Login(string emailId, string password)
        {
            var result = _userService.CompanyLogin(emailId, password);

            if (result)
            {
                return RedirectToAction("CompanyDashboard");
            }
            else
            {
                return RedirectToAction("CompanyLogin");
            }
        }
        public IActionResult RegisterCompany()
        {
            CreateCompanyVM createCompanyVM = new CreateCompanyVM();
            createCompanyVM.CountryList = _masterDataService.GetCountries().Select(x => new SelectListItem()
            {
                Text = x.Name,
                Value = x.Id.ToString()
            }).ToList();
            createCompanyVM.BusinessTypeList = _masterDataService.GetBusinessTypes().Select(x => new SelectListItem()
            {
                Text = x.Name,
                Value = x.Id.ToString()
            }).ToList();
            return View(createCompanyVM);
        }
        public IActionResult Create(CreateCompanyVM createCompanyVM)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<CreateCompanyVM, RegisterCompanyDTO>());
            var mapper = new Mapper(config);
            RegisterCompanyDTO dto = mapper.Map<RegisterCompanyDTO>(createCompanyVM);
            var cid = _userService.CreateCompany(dto);
            if (cid > 0)
            {
                return RedirectToAction("CompanyDashboard");
            }
            else
            {
                return RedirectToAction("RegisterCompany");
            }

        }
    }
}

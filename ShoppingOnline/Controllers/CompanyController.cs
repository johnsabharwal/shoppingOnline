﻿using System;
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

        public IActionResult CompanyDashboard()
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
        public IActionResult Departments()
        {
            ViewBag.Class = "inner-page";
            AddDepartmentVM addDepartmentVM = new AddDepartmentVM();
            return View(addDepartmentVM);
        }
        public ActionResult Students(int draw)
        {
            Models.BaseDataTable dataTable = new Models.BaseDataTable();

            List<Models.Department> students = new List<Models.Department>();
            students.Add(new Models.Department { Id = 1, Name = "Mike", SurName = "Mikey", ClassRoom = "8A" });
            students.Add(new Models.Department { Id = 2, Name = "John", SurName = "Salary", ClassRoom = "8B" });
            students.Add(new Models.Department { Id = 3, Name = "Steve", SurName = "Brown", ClassRoom = "7A" });
            string filterName = "";
            string filterSurName = "";// Request.QueryString["surname"];
            string filterClassroom = "";//Request.QueryString["classroom"];

            var result = from s in students
                where (string.IsNullOrEmpty(filterName) || s.Name.Equals(filterName))
                      && (string.IsNullOrEmpty(filterSurName) || s.SurName.Equals(filterSurName))
                      && (string.IsNullOrEmpty(filterClassroom) || s.ClassRoom.Equals(filterClassroom))
                select s;
            var model = result.ToList();
            dataTable.draw = draw;

           dataTable.data = result.ToArray();
            dataTable.recordsTotal = students.Count;
            dataTable.recordsFiltered = result.Count();
            return Json(model);

        }
        public IActionResult Officers()
        {
            AddOfficerVM addOfficerVM = new AddOfficerVM();

            return View(addOfficerVM);
        }
        public IActionResult Employees()
        {
            AddEmployeeVM addEmployeeVM = new AddEmployeeVM();

            return View(addEmployeeVM);
        }
        public IActionResult Suppliers()
        {
            AddSuppliersVM addSuppliersVM = new AddSuppliersVM();

            return View(addSuppliersVM);
        }
        public IActionResult Products()
        {
            AddProductVM addProductVM=new AddProductVM();
            return View(addProductVM);
        }
        public IActionResult Promoters()
        {
            AddPromotersVM addPromotersVM=new AddPromotersVM();
            return View(addPromotersVM);
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
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
        public IActionResult Departments(int companyId)
        {
            ViewBag.Class = "inner-page";
            AddDepartmentVM addDepartmentVM = new AddDepartmentVM();
            addDepartmentVM.CompanyId = companyId;
            return View(addDepartmentVM);
        }
        public IActionResult CreateDepartment(AddDepartmentVM addDepartmentVM)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<AddDepartmentVM, AddDepartmentDTO>());
            var mapper = new Mapper(config);
            AddDepartmentDTO dto = mapper.Map<AddDepartmentDTO>(addDepartmentVM);
            _userService.CreateAndUpdateDepartment(dto);
            return RedirectToAction("Departments", "Company", new { companyId = dto.CompanyId });
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
        public IActionResult Officers(int companyId)
        {
            AddOfficerVM addOfficerVM = new AddOfficerVM();
            addOfficerVM.CompanyId = companyId;
            addOfficerVM.DepartmentList = _masterDataService.GetDepartments(companyId).Select(x => new SelectListItem() { Text = x.DepartmentName, Value = x.Id.ToString() });
            return View(addOfficerVM);
        }
        public IActionResult CreateOfficer(AddOfficerVM addOfficerVM)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<AddOfficerVM, AddOfficerDTO>());
            var mapper = new Mapper(config);
            AddOfficerDTO dto = mapper.Map<AddOfficerDTO>(addOfficerVM);
            _userService.CreateAndUpdateOfficer(dto);
            return RedirectToAction("Officers", "Company", new { companyId = dto.CompanyId });
        }
        public IActionResult Employees(int companyId)
        {
            AddEmployeeVM addEmployeeVM = new AddEmployeeVM();
            addEmployeeVM.CompanyId = companyId;
            addEmployeeVM.DepartmentList = _masterDataService.GetDepartments(companyId).Select(x => new SelectListItem() { Text = x.DepartmentName, Value = x.Id.ToString() });
            return View(addEmployeeVM);
        }
        public IActionResult CreateEmployee(AddEmployeeVM addEmployeeVM)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<AddEmployeeVM, AddEmployeeDTO>());
            var mapper = new Mapper(config);
            AddEmployeeDTO dto = mapper.Map<AddEmployeeDTO>(addEmployeeVM);
            _userService.CreateAndUpdateEmployee(dto);
            return RedirectToAction("Employees", "Company", new { companyId = dto.CompanyId });
        }
        public IActionResult Suppliers(int companyId)
        {
            AddSuppliersVM addSuppliersVM = new AddSuppliersVM();
            addSuppliersVM.CompanyId = companyId;
            return View(addSuppliersVM);
        }
        public IActionResult CreateSupplier(AddSuppliersVM addSuppliersVM)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<AddSuppliersVM, AddSupplierDTO>());
            var mapper = new Mapper(config);
            AddSupplierDTO dto = mapper.Map<AddSupplierDTO>(addSuppliersVM);
            _userService.CreateAndUpdateSuppplier(dto);
            return RedirectToAction("Suppliers", "Company", new { companyId = dto.CompanyId });
        }
        public IActionResult Products(int companyId)
        {
            AddProductVM addProductVM = new AddProductVM();
            addProductVM.CompanyId = companyId;
            addProductVM.Category = new List<SelectListItem>()
                {new SelectListItem() {Text = "Electronics", Value = "1"}};
            return View(addProductVM);
        }
        public IActionResult AddProduct(AddProductVM addProductVM)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<AddProductVM, AddProductDTO>());
            var mapper = new Mapper(config);
            AddProductDTO dto = mapper.Map<AddProductDTO>(addProductVM);

            var files = HttpContext.Request.Form.Files;
            foreach (var Image in files)
            {
                if (Image != null && Image.Length > 0)
                {
                    var file = Image;
                    var uploads = Path.Combine("", "uploads\\img");
                    if (file.Length > 0)
                    {
                        var fileName = Guid.NewGuid().ToString().Replace("-", "") + Path.GetExtension(file.FileName);
                        using (var fileStream = new FileStream(Path.Combine(uploads, fileName), FileMode.Create))
                        {
                            file.CopyToAsync(fileStream);
                            addProductVM.ImagePath = fileName;
                        }

                    }
                }
            }
            _userService.CreateAndUpdateProduct(dto);
            return RedirectToAction("Products", "Company", new { companyId = dto.CompanyId });
        }

        public string UploadProductImage(AddProductVM addProductVM)
        {

            return "";
        }
        public IActionResult Promoters(int companyId)
        {
            AddPromotersVM addPromotersVM = new AddPromotersVM();
            addPromotersVM.CompanyId = companyId;
            return View(addPromotersVM);
        }
        public IActionResult CreatePromoter(AddPromotersVM addPromotersVM)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<AddPromotersVM, AddPromotersDTO>());
            var mapper = new Mapper(config);
            AddPromotersDTO dto = mapper.Map<AddPromotersDTO>(addPromotersVM);
            _userService.CreateAndUpdatePromoter(dto);
            return RedirectToAction("Promoters", "Company", new { companyId = dto.CompanyId });
        }
    }
}

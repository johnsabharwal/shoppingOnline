using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Dal.DTO;
using Dal.Interface;
using Dal.Migrations;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using ShoppingOnline.Models;

namespace ShoppingOnline.Controllers
{
    public class CompanyController : BaseController
    {
        private readonly IUserService _userService;
        private readonly IMasterDataService _masterDataService;
        private readonly IWebHostEnvironment webHostEnvironment;
        public CompanyController(IUserService userService,
            IMasterDataService masterDataService,
            IWebHostEnvironment hostEnvironment)
        {
            base._masterDataService = masterDataService;
            _userService = userService;
            _masterDataService = masterDataService;
            webHostEnvironment = hostEnvironment;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult CompanyLogin()
        {
            ViewBag.menu = JsonConvert.SerializeObject(GetCategory());

            return View();
        }

        public IActionResult CompanyDashboard(int companyId)
        {
            ViewBag.CompanyId = companyId;
            return RedirectToAction("Products", new {companyId = companyId});
        }
        public IActionResult Login(string emailId, string password)
        {
            var result = _userService.CompanyLogin(emailId, password);
            ViewBag.menu = JsonConvert.SerializeObject(GetCategory());

            if (result != null)
            {
                ShowToaster("Welcome", ToasterLevel.Success);
                TempData["isLogin"] = 1;
                TempData["cid"] = result.Id;
                TempData["companyname"] = result.Name;
                return RedirectToAction("CompanyDashboard", new { companyId = result.Id });
            }
            else
            {
                ShowToaster("Invalid Username/Password", ToasterLevel.Danger);
                return RedirectToAction("CompanyLogin");
            }
        }
        public IActionResult RegisterCompany()
        {
            ViewBag.menu = JsonConvert.SerializeObject(GetCategory());

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
            RegisterCompanyDTO dto = mapper.DefaultContext.Mapper.Map<RegisterCompanyDTO>(createCompanyVM);
            var cid = _userService.CreateCompany(dto);
            if (cid > 0)
            {
                ShowToaster("Welcome", ToasterLevel.Success);
                return RedirectToAction("CompanyDashboard");
            }
            else
            {
                ShowToaster("Email-id already exists for this company", ToasterLevel.Danger);
                return RedirectToAction("RegisterCompany");
            }

        }
        public IActionResult Departments(int companyId)
        {
            ViewBag.Class = "inner-page";
            AddDepartmentVM addDepartmentVM = new AddDepartmentVM();
            addDepartmentVM.CompanyId = companyId;
            ViewBag.CompanyId = companyId;

            return View(addDepartmentVM);
        }
        public IActionResult CreateDepartment(AddDepartmentVM addDepartmentVM)
        {
            if (!ModelState.IsValid)
            {
                ShowToaster("Please fill required fields", ToasterLevel.Danger);
                return RedirectToAction("Departments", "Company", new { companyId = addDepartmentVM.CompanyId });
            }
            var config = new MapperConfiguration(cfg => cfg.CreateMap<AddDepartmentVM, AddDepartmentDTO>());
            var mapper = new Mapper(config);
            AddDepartmentDTO dto = mapper.DefaultContext.Mapper.Map<AddDepartmentDTO>(addDepartmentVM);
            _userService.CreateAndUpdateDepartment(dto);
            ShowToaster("Department created successfully", ToasterLevel.Success);

            return RedirectToAction("Departments", "Company", new { companyId = dto.CompanyId });
        }

        public IActionResult Officers(int companyId)
        {
            ViewBag.CompanyId = companyId;

            AddOfficerVM addOfficerVM = new AddOfficerVM();
            addOfficerVM.CompanyId = companyId;
            addOfficerVM.DepartmentList = _masterDataService.GetDepartments(companyId).Select(x => new SelectListItem() { Text = x.DepartmentName, Value = x.Id.ToString() });
            return View(addOfficerVM);
        }
        public IActionResult CreateOfficer(AddOfficerVM addOfficerVM)
        {
            if (!ModelState.IsValid)
            {
                ShowToaster("Please fill required fields", ToasterLevel.Danger);
                return RedirectToAction("Officers", "Company", new { companyId = addOfficerVM.CompanyId });
            }
            var config = new MapperConfiguration(cfg => cfg.CreateMap<AddOfficerVM, AddOfficerDTO>());
            var mapper = new Mapper(config);
            AddOfficerDTO dto = mapper.DefaultContext.Mapper.Map<AddOfficerDTO>(addOfficerVM);
            _userService.CreateAndUpdateOfficer(dto);
            ShowToaster("Officer created successfully", ToasterLevel.Success);

            return RedirectToAction("Officers", "Company", new { companyId = dto.CompanyId });
        }
        public IActionResult Employees(int companyId)
        {
            ViewBag.CompanyId = companyId;

            AddEmployeeVM addEmployeeVM = new AddEmployeeVM();
            addEmployeeVM.CompanyId = companyId;
            addEmployeeVM.DepartmentList = _masterDataService.GetDepartments(companyId).Select(x => new SelectListItem() { Text = x.DepartmentName, Value = x.Id.ToString() });
            return View(addEmployeeVM);
        }
        public IActionResult CreateEmployee(AddEmployeeVM addEmployeeVM)
        {
            if (!ModelState.IsValid)
            {
                ShowToaster("Please fill required fields", ToasterLevel.Danger);
                return RedirectToAction("Employees", "Company", new { companyId = addEmployeeVM.CompanyId });
            }
            var config = new MapperConfiguration(cfg => cfg.CreateMap<AddEmployeeVM, AddEmployeeDTO>());
            var mapper = new Mapper(config);
            AddEmployeeDTO dto = mapper.DefaultContext.Mapper.Map<AddEmployeeDTO>(addEmployeeVM);
            _userService.CreateAndUpdateEmployee(dto);
            ShowToaster("Employee created successfully", ToasterLevel.Success);

            return RedirectToAction("Employees", "Company", new { companyId = dto.CompanyId });
        }
        public IActionResult Suppliers(int companyId)
        {
            ViewBag.CompanyId = companyId;

            AddSuppliersVM addSuppliersVM = new AddSuppliersVM();
            addSuppliersVM.CompanyId = companyId;
            return View(addSuppliersVM);
        }
        public IActionResult CreateSupplier(AddSuppliersVM addSuppliersVM)
        {
            if (!ModelState.IsValid)
            {
                ShowToaster("Please fill required fields", ToasterLevel.Danger);
                return RedirectToAction("Suppliers", "Company", new { companyId = addSuppliersVM.CompanyId });
            }
            var config = new MapperConfiguration(cfg => cfg.CreateMap<AddSuppliersVM, AddSupplierDTO>());
            var mapper = new Mapper(config);
            AddSupplierDTO dto = mapper.DefaultContext.Mapper.Map<AddSupplierDTO>(addSuppliersVM);
            _userService.CreateAndUpdateSuppplier(dto);
            ShowToaster("Supplier created successfully", ToasterLevel.Success);

            return RedirectToAction("Suppliers", "Company", new { companyId = dto.CompanyId });
        }
        public IActionResult Products(int companyId, int productId)
        {
            AddProductVM addProductVM = new AddProductVM();
            addProductVM.CompanyId = companyId;
            addProductVM.Category = _masterDataService.GetCategory().Select(x => new SelectListItem() { Value = x.Id.ToString(), Text = x.Name });
            var product = _userService.GetProductById(productId);
            if (product != null)
            {
                addProductVM.UploadPath =
                    System.IO.File.Exists(Path.Combine(webHostEnvironment.WebRootPath, "images/" + product.ImagePath))
                        ? "/images/" + product.ImagePath
                        : "/images/noimage.png";
                addProductVM.ProductName = product.ProductName;
                addProductVM.ProductId = product.Id;
                addProductVM.Price = product.Price.ToString();
                addProductVM.DiscountPrice = (product.Price - product.Price * product.Discount / 100).ToString();
                addProductVM.Description = product.Description;
                addProductVM.ProductCode = product.ProductCode;
                addProductVM.Discount = product.Discount.ToString();

            }
            ViewBag.CompanyId = companyId;

            return View(addProductVM);
        }
        [HttpPost]
        public IActionResult AddProduct(AddProductVM addProductVM)
        {
            if (!ModelState.IsValid)
            {
                ShowToaster("Please fill required fields", ToasterLevel.Danger);
                return RedirectToAction("Products", "Company", new { companyId = addProductVM.CompanyId });
            }
            var config = new MapperConfiguration(cfg => cfg.CreateMap<AddProductVM, AddProductDTO>());
            var mapper = new Mapper(config);
            AddProductDTO dto = mapper.DefaultContext.Mapper.Map<AddProductDTO>(addProductVM);
            dto.ImagePath = UploadedFile(addProductVM);
            _userService.CreateAndUpdateProduct(dto);
            var status = addProductVM.ProductId == 0 ? "Created" : "Updated";
            ShowToaster("Product " + status + " successfully", ToasterLevel.Success);

            return RedirectToAction("Products", "Company", new { companyId = dto.CompanyId });
        }
        private string UploadedFile(AddProductVM model)
        {
            string uniqueFileName = null;

            if (model.ImagePath != null)
            {
                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.ImagePath.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.ImagePath.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }
        public IActionResult DeleteProduct(int ProductId, int CompanyId)
        {

            _userService.DeleteProduct(ProductId);
            ShowToaster("Product deleted successfully", ToasterLevel.Success);

            return RedirectToAction("Products", "Company", new { companyId = CompanyId });
        }

        
        public IActionResult Promoters(int companyId)
        {
            ViewBag.CompanyId = companyId;

            AddPromotersVM addPromotersVM = new AddPromotersVM();
            addPromotersVM.CompanyId = companyId;
            return View(addPromotersVM);
        }
        public IActionResult CreatePromoter(AddPromotersVM addPromotersVM)
        {
            if (!ModelState.IsValid)
            {
                ShowToaster("Please fill required fields", ToasterLevel.Danger);
                return RedirectToAction("Promoters", "Company", new { companyId = addPromotersVM.CompanyId });
            }
            var config = new MapperConfiguration(cfg => cfg.CreateMap<AddPromotersVM, AddPromotersDTO>());
            var mapper = new Mapper(config);
            AddPromotersDTO dto = mapper.DefaultContext.Mapper.Map<AddPromotersDTO>(addPromotersVM);
            _userService.CreateAndUpdatePromoter(dto);
            ShowToaster("Promoter created successfully", ToasterLevel.Success);

            return RedirectToAction("Promoters", "Company", new { companyId = dto.CompanyId });
        }


        public IActionResult Orders(int companyId)
        {
            ViewBag.CompanyId = companyId;

            GetOrdersVM getOrdersVM = new GetOrdersVM();
            getOrdersVM.CompanyId = companyId;
            getOrdersVM.OrderList = _userService.GetOrdersId().Select(x => new SelectListItem() { Value = x.ToString(), Text = x.ToString() });
            getOrdersVM.OrderStatus = _masterDataService.GetOrderStatus().Select(x => new SelectListItem() { Value = x.Id.ToString(), Text = x.Name });
            return View(getOrdersVM);
        }
        public IActionResult UpdateOrder(int orderId, int statusId, int companyId)
        {
            _userService.UpdateOrder(orderId, statusId);
            ShowToaster("Order update successfully", ToasterLevel.Success);

            return RedirectToAction("Orders", new { companyId = companyId });
        }
    }
}

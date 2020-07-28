using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Dal.DTO;
using Dal.Interface;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using ShoppingOnline.Models;

namespace ShoppingOnline.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IUserService _userService;
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly IMasterDataService _masterDataService;

        public HomeController(IUserService userService,
            IWebHostEnvironment hostEnvironment,
            IMasterDataService masterDataService)
        {
            _userService = userService;
            webHostEnvironment = hostEnvironment;
            _masterDataService = masterDataService;
        }

        public IActionResult Index(string search, string filter, int page = 1)
        {
            GetProducts getProducts = new GetProducts();
            ViewBag.Class = "";
            var products = getProducts.products = _userService.GetProducts(0, search, filter).Select(x => new AddProductVM()
            {
                UploadPath = System.IO.File.Exists(Path.Combine(webHostEnvironment.WebRootPath, "images/" + x.ImagePath)) ? "/images/" + x.ImagePath : "/images/noimage.png",
                ProductName = x.ProductName,
                ProductId = x.Id,
                Price = x.Price.ToString(),
                DiscountPrice = (x.Price - x.Price * x.Discount / 100).ToString()
            }).ToList();
            getProducts.total = products.Count();
            getProducts.page = page;
            ViewBag.page = page;
            ViewBag.filter = filter ?? "Popular";
            ViewBag.search = search;
            getProducts.products = products.Skip((page - 1) * 12).Take(12).ToList();

            return View(getProducts);
        }

        public IActionResult Product(int id)
        {
            var product = _userService.GetProductById(id);
            AddProductVM vm = new AddProductVM()
            {
                UploadPath =
                    System.IO.File.Exists(Path.Combine(webHostEnvironment.WebRootPath, "images/" + product.ImagePath))
                        ? "/images/" + product.ImagePath
                        : "/images/noimage.png",
                ProductName = product.ProductName,
                ProductId = product.Id,
                Price = product.Price.ToString(),
                DiscountPrice = (product.Price - product.Price * product.Discount / 100).ToString(),
                Description = product.Description,
            };
            ViewBag.SimilarProducts = _userService.GetProductByCategoryId(product.SubCategoryId).Select(x => new AddProductVM()
            {
                UploadPath = System.IO.File.Exists(Path.Combine(webHostEnvironment.WebRootPath, "images/" + x.ImagePath))
                    ? "/images/" + x.ImagePath
                    : "/images/noimage.png",
                ProductName = product.ProductName,
                ProductId = product.Id,
                Price = product.Price.ToString(),
                DiscountPrice = (product.Price - product.Price * product.Discount / 100).ToString(),
            }).ToList();
            return View(vm);
        }
        public IActionResult Checkout()
        {
            return View();
        }
        public IActionResult PlaceOrder(int userid)
        {
            PlaceOrderVM placeOrderVM = new PlaceOrderVM();
            var user = _userService.GetUserById(userid);
            placeOrderVM.User.UserName = user.Name;
            placeOrderVM.User.EmailId = user.EmailId;
            placeOrderVM.User.Address = user.Address;
            placeOrderVM.User.Contact = user.ContactNumber;
            placeOrderVM.User.CountryId = user.CountryId;
            placeOrderVM.User.StateId = user.StateId;
            placeOrderVM.User.Id = user.Id;
            placeOrderVM.User.Pincode = user.PinCode;
            placeOrderVM.User.CountryList = _masterDataService.GetCountries().Select(x => new SelectListItem()
            {
                Text = x.Name,
                Value = x.Id.ToString()
            }).ToList();
            placeOrderVM.User.StateList = _masterDataService.GetStates(user.CountryId).Select(x => new SelectListItem()
            {
                Text = x.Name,
                Value = x.Id.ToString()
            }).ToList();

            return View(placeOrderVM);
        }
        public IActionResult Privacy()
        {
            return View();
        }
        [HttpPost]
        public IActionResult GetCart(List<string> items)
        {
            List<AddProductVM> products = new List<AddProductVM>();
            ViewBag.Class = "";
            products = _userService.GetProductsByIds(items).Select(x => new AddProductVM()
            {
                UploadPath = System.IO.File.Exists(Path.Combine(webHostEnvironment.WebRootPath, "images/" + x.ImagePath)) ? "/images/" + x.ImagePath : "/images/noimage.png",
                ProductName = x.ProductName,
                ProductId = x.Id,
                Price = x.Price.ToString(),
                Description = x.Description.ToString(),
                DiscountPrice = (x.Price - x.Price * x.Discount / 100).ToString()
            }).ToList();
            return Json(products);
        }

        public IActionResult Thankyou(PlaceOrderVM placeOrderVM)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<PlaceOrderVM, PlaceOrderDTO>());
            var mapper = new Mapper(config);
            PlaceOrderDTO dto = mapper.DefaultContext.Mapper.Map<PlaceOrderDTO>(placeOrderVM);
            ViewBag.OrderId = _userService.PlaceOrder(dto, placeOrderVM.User.Id);
            ShowToaster("Order Placed successfully", ToasterLevel.Success);

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

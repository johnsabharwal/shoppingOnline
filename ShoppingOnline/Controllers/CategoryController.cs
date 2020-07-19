using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dal.Interface;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ShoppingOnline.Controllers
{
    public class CategoryController : Controller
    {

        private readonly IMasterDataService _masterDataService;
        public CategoryController(
            IMasterDataService masterDataService)
        {
            _masterDataService = masterDataService;
        }
        public IActionResult GetSubCategory(int categoryId)
        {
           var data= _masterDataService.GetSubCategory(categoryId);
            return Json(data);
        }
        public IActionResult GetStates(int countryId)
        {
            var data = _masterDataService.GetStates(countryId);
            return Json(data);
        }
    }
}

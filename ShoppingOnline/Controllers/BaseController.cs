using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Dal.DTO;
using Dal.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ShoppingOnline.Models;

namespace ShoppingOnline.Controllers
{
    public class BaseController : Controller
    {

        public IMasterDataService _masterDataService;
        [NonAction]
        protected void ShowToaster(string message, ToasterLevel level = ToasterLevel.Success)
        {

            TempData["ToasterMessage"] = message;

            switch (level)
            {
                case ToasterLevel.Success:
                    TempData["ToasterLevel"] = "success";
                    break;

                case ToasterLevel.Info:
                    TempData["ToasterLevel"] = "info";
                    break;

                case ToasterLevel.Warning:
                    TempData["ToasterLevel"] = "warning";
                    break;

                case ToasterLevel.Danger:
                    TempData["ToasterLevel"] = "danger";
                    break;
            }
        }
        protected enum ToasterLevel
        {
            Success,
            Info,
            Warning,
            Danger
        }

        public CategoryVM GetCategory()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<CategoryVM, CategoryDTO>());
            var mapper = new Mapper(config);
            return mapper.DefaultContext.Mapper.Map<CategoryVM>(_masterDataService.GetAllCategories());
        }

    }
}

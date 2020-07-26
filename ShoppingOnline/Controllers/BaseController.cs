using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ShoppingOnline.Controllers
{
    public class BaseController : Controller
    {
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
    }
}

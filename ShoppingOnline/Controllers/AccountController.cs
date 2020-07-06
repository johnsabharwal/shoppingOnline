using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ShoppingOnline.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            ViewBag.Class = "inner-page";
            return View();
        }
        public IActionResult Register()
        {
            ViewBag.Class = "inner-page";
            return View();
        }
    }
}

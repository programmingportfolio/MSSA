using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SoftwareStore.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Checkout1()
        {
            return View();
        }
        public IActionResult Checkout2()
        {
            return View();
        }
        public IActionResult Checkout3()
        {
            return View();
        }
        public IActionResult Checkout4()
        {
            return View();
        }

        public IActionResult Cart()
        {
            return View();
        }
        public IActionResult Order()
        {
            return View();
        }
        public IActionResult Orders()
        {
            return View();
        }
    }
}

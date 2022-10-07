using AJAXdemo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace AJAXdemo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult First()
        {
            return View();
        }

        public IActionResult Get()
        {
            return View();
        }

        public IActionResult AjaxEvent()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        //下拉式選單顯示縣市
        public IActionResult Address()
        {
            return View();
        }

        public IActionResult Promise()
        {
            return View();
        }

        //Fretch方法是全域變數
        public IActionResult Fetch()
        {
            return View();
        }


        public IActionResult History()
        {
            return View();
        }

        public IActionResult jQuery()
        {
            return View();
        }

        public IActionResult ShipperCors()
        {
            return View();
        }

        public IActionResult ShipperCorsEmpty()
        {
            return View();
        }


        public IActionResult AutoComplete()
        {
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

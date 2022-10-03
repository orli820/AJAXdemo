using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AJAXdemo.Controllers
{
    public class APIController : Controller
    {
        //http://localhost.API/Index
        public IActionResult Index()
        {
            //回應單純的字串 "Hello Ajax"
            //return Content("<h2>Hello Ajax</h2>"); //會顯示<h2>Hello Ajax</h2> 顯示為文字
            return Content("<h2>Hello Ajax!!</h2>","text/html",System.Text.Encoding.UTF8); //參數(內容,字串格式,Encoding的類型)
        }

        
    }
}

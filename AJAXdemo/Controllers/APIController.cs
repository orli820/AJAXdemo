using AJAXdemo.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AJAXdemo.Controllers
{
    public class APIController : Controller
    {
        //http://localhost.API/Index

        private readonly IWebHostEnvironment _host;
        private readonly DemoContext _context;
        public APIController(IWebHostEnvironment host, DemoContext context)
        {
            _host = host;
            _context = context;
        }
        public IActionResult Index(string keyword)  //接收瀏覽器回傳的資料
        {

            if (String.IsNullOrEmpty(keyword))
            {
                keyword = "Ajax";
            }
            //回應單純的字串 "Hello Ajax"
            //return Content("<h2>Hello Ajax</h2>"); //會顯示<h2>Hello Ajax</h2> 顯示為文字
            return Content($"{keyword},您好!", "text/html", System.Text.Encoding.UTF8); //參數(內容,字串格式,Encoding的類型)
        }

        public IActionResult sleep()  //接收瀏覽器回傳的資料
        {
            //進入會停五秒
            System.Threading.Thread.Sleep(5000);
            return Content("Hello Ajax envet", "text/plain");
        }

        public IActionResult Register(Member member, IFormFile File1)  //參數名稱要跟Name屬性一樣 "File1"
        {

            //檔案上傳要知道實際路徑
            //Eg. C:\Users\Student\source\repos\AJAXdemo\AJAXdemo\wwwroot\uploads
            // C: \Inetpub\wwwroot\AJAXdemo\wwwroot\uploads  wwwroot實際路徑

            string info = $"{File1.FileName}-{File1.ContentType}";                              //測試檔案名稱是法正確
            string info1 = _host.WebRootPath;                                                    //專案路徑 (後面多了wwwroot)
            string info2 = _host.ContentRootPath;                                               //本機實際路徑            
            string filePath = Path.Combine(_host.WebRootPath, "uploads", File1.FileName);         //檔案實際路徑+名稱

            //上傳圖檔會分割成不同大小的封包依序傳送到client端 ==> 資料流
            //將檔案存到實體資料夾中
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                File1.CopyTo(fileStream);
            }

            //將檔案轉成二進位  將檔案寫在記憶體中
            byte[] imgByte = null;
            using (var memortStream = new MemoryStream())
            {
                File1.CopyTo(memortStream);
                imgByte = memortStream.ToArray();           //轉成陣列
            }

           
            member.FileName = File1.FileName;
            member.FileData = imgByte;

            //寫進資料庫
            _context.Members.Add(member);
            _context.SaveChanges();
            return Content(filePath, "text/plain");
        }
    }
}

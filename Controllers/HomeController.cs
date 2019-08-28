using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using GoodApple.Models;

namespace GoodApple.Controllers {
    public class HomeController : Controller {
        private GoodAppleContext dbContext;

        public HomeController(GoodAppleContext context) {
            dbContext = context;
        }

        public IActionResult Index(){
            return View();
        }

<<<<<<< HEAD
        [HttpGet("projects")]
        public IActionResult AllProjects()
        {
            return View();
        }
        [HttpGet("projectinfo")]
        public IActionResult ProjectInfo()
        {
            return View();
=======
        [HttpGet("logout")]
        public IActionResult Logout(){
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
>>>>>>> 97d1ebe5ae5e3c5b32abd4b15a25bc65d8dffdcc
        }
    }
}

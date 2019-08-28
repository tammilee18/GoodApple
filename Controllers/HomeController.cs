using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using GoodApple.Models;

namespace GoodApple.Controllers
{
    public class HomeController : Controller
    {
        private GoodAppleContext dbContext;

        public HomeController(GoodAppleContext context) {
            dbContext = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("projects")]
        public IActionResult AllProjects()
        {
            return View();
        }
        [HttpGet("projectinfo")]
        public IActionResult ProjectInfo()
        {
            return View();
        }
    }
}

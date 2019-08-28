using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using GoodApple.Models;
using Microsoft.AspNetCore.Identity;

namespace GoodApple.Controllers
{
    public class TeacherController : Controller
    {
        private GoodAppleContext dbContext;

        public int? InSession
        {
            get { return HttpContext.Session.GetInt32("UserId"); }
            set { HttpContext.Session.SetInt32("UserId", (int)value); }
        }

        public TeacherController(GoodAppleContext context) {
            dbContext = context;
        }

        //All things regarding teachers
        [HttpGet("newteacher")]
        public IActionResult NewTeacher()
        {
            return View("TeacherReg");
        }

        [HttpPost("newteacher")]
        public IActionResult Create(Teacher newTeacher)
        {
            if (ModelState.IsValid)
            {
                if (dbContext.users.Any(user => user.Email == newTeacher.Email))
                {
                    ModelState.AddModelError("Email", "Email is already in use!");
                    return View("TeacherReg");
                }
                // Initializing a PasswordHasher object, providing our User class as its
                PasswordHasher<User> hasher = new PasswordHasher<User>();
                string hashedPw = hasher.HashPassword(newTeacher, newTeacher.Password);
                newTeacher.Password = hashedPw;
                //Save your user object to the database
                dbContext.users.Add(newTeacher);
                dbContext.SaveChanges();
                InSession = newTeacher.UserId;
                return RedirectToAction("TeachDashboard");
            }
            return View("TeacherReg");
        }

        [HttpGet("dashboard")]
        public IActionResult TeachDashboard()
        {
            // if(InSession == null){
            //     return View("Index", "Home");
            // }

            List<Project> AllProjects = dbContext.projects.ToList();
            return View();
        }

        [HttpPost("newproject")]
        public IActionResult NewProject(Project newProject)
        {

            if(ModelState.IsValid){
                newProject.CreatorId = 1;
                dbContext.projects.Add(newProject);
                dbContext.SaveChanges();
                 return RedirectToAction("TeachDashboard");
            }
            return View("TeachDashboard");
        }

    }

}
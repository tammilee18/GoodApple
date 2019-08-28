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
    public class DonorController : Controller {
        private GoodAppleContext dbContext;

        public DonorController(GoodAppleContext context) {
            dbContext = context;
        }

        [HttpGet("newDonor")]
        public IActionResult newDonor(){
            return View();
        }

        [HttpPost("addDonor")]
        public IActionResult addDonor(Donor newDonor){
            if(ModelState.IsValid){
                if(dbContext.users.Any(u => u.Email == newDonor.Email)){
                    ModelState.AddModelError("Email", "Email is already in use!");
                    return View("newDonor");
                } else {
                    PasswordHasher<User> Hasher = new PasswordHasher<User>();
                    newDonor.Password = Hasher.HashPassword(newDonor, newDonor.Password);
                    dbContext.Add(newDonor);
                    dbContext.SaveChanges();
                    if(HttpContext.Session.GetInt32("UserId") == null){
                        HttpContext.Session.SetInt32("UserId", newDonor.UserId);
                    }
                    return RedirectToAction("DonorDashboard");
                }
            } else {
                System.Console.WriteLine("*******************");
                System.Console.WriteLine("REGISTRATION NOT WORKING!!!!");
                System.Console.WriteLine(newDonor.FirstName);
                System.Console.WriteLine(newDonor.LastName);
                System.Console.WriteLine(newDonor.Email);
                System.Console.WriteLine("*******************");
                return View("newDonor");
            }
        }

        [HttpPost("DonorLogin")]
        public IActionResult DonorLogin(LoginUser existingUser){
            if(ModelState.IsValid){
                User userInDB = dbContext.users.FirstOrDefault(u => u.Email == existingUser.Email);
                if(userInDB == null){
                    ModelState.AddModelError("Email", "Invalid email or password");
                    return View("Index");
                } else {
                    var hasher = new PasswordHasher<LoginUser>();
                    var result = hasher.VerifyHashedPassword(existingUser, userInDB.Password, existingUser.Password);
                    if(result == 0){
                        ModelState.AddModelError("Password", "Invalid email or password");
                        return RedirectToAction("Index");
                    }
                    if(HttpContext.Session.GetInt32("UserId") == null){
                        HttpContext.Session.SetInt32("UserId", userInDB.UserId);
                    }
                    return RedirectToAction("DonorDashboard");
                }
            } else {
                return View("Index");
            }
        }

        [HttpGet("DonorDashboard")]
        public IActionResult DonorDashboard(){
            return View();
        }

    }
}
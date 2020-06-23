using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using infra.Models;
using Service;


namespace cg2labweb.Controllers
{
    public class LoginController : Controller
    {

        public IActionResult Login(string studentid)
        {
            StudentData stuDt = new StudentData();
            if(stuDt.Studentid == studentid)
            {
                
            }
            return View();
        }

        public IActionResult Registered()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult Registered(StudentData stuDt)
        {
            if (ModelState.IsValid)
            {
                
            }

            return RedirectToAction("Index");
        }

        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        public IActionResult Index2()
        {           
            return View();
        }

    }
}
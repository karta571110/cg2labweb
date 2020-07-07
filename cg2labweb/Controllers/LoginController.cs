using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using infra.Models;
using Service;
using infra.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;

namespace cg2labweb.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(ViewStudentData student)
        {
            
            using (var content = new ContextFactory().dbContext())
            {
                var query = content.StudentData
                            .Where(m => m.Studentid == student.Studentid && m.Password == student.Password)
                            .FirstOrDefault();
                if (query == null)
                {
                    ViewBag.Massage = "帳密錯誤，登入失敗";
                    return RedirectToAction("Login");
                }
                CookieOptions cookieOptions = new CookieOptions();
                cookieOptions.Expires = DateTime.Now.AddDays(7);
                Response.Cookies.Append("studentid", student.Studentid, cookieOptions);                
            }

            return RedirectToAction("Index","home");
        }

        public IActionResult Registered()
        {
            if (ModelState.IsValid)
            {
                var ViewStudentData = new List<ViewStudentData>();
                using (var content = new ContextFactory().dbContext())
                {
                    var query = from q in content.StudentData
                                orderby q.id ascending
                                where q.id != 0
                                select new ViewStudentData
                                {
                                    id = q.id,
                                    UserName = q.UserName,
                                    Password = q.Password,
                                    Email = q.Email,
                                    Studentid = q.Studentid,
                                    Status=q.Status
                                };
                    if (query.Any())
                    {
                        ViewStudentData = query.ToList();
                    }
                }
            }
            return View();
        }
        
        [HttpPost]
        public IActionResult Registered(ViewStudentData student)
        {
            if (ModelState.IsValid)
            {
                using (var content = new ContextFactory().dbContext())
                {
                    var studentData = new StudentData
                    {
                        UserName = student.UserName,
                        Password = student.Password,
                        Studentid = student.Studentid,
                        Email = student.Email,
                        Status=student.Status
                    };

                    content.StudentData.Add(studentData);
                    content.SaveChanges();
                    return RedirectToAction("Registered");
                }
            }
            return View(student);
        }

    }
}
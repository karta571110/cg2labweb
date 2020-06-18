using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using infra.Models;
using Service;

namespace prjcg2lab.Controllers
{
    public class DashboradController : Controller
    {
        private ContextFactory cf = new ContextFactory();
        // GET: Dashborad
        public ActionResult Dashboard()
        {
            cf.db.Members.Add(new Member
            {
                Account="asd",
                Password="ddddddd"
            });
            cf.db.SaveChanges();
            return View();
            
        }
    }
}
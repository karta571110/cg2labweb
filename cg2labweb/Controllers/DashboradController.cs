﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNetCore.Mvc;

namespace prjcg2lab.Controllers
{
    public class DashboradController : Controller
    {
        // GET: Dashborad
        public ActionResult Dashboard()
        {
            return View();
        }
    }
}
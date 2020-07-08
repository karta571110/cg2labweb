using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace cg2labweb.Controllers
{
    public class ManagerController : Controller
    {
        private IHostingEnvironment _env; //虛擬機環境
        private string _dir;

        public ManagerController(IHostingEnvironment env)
        {
            _env = env;
            _dir = _env.ContentRootPath;
        }
        public IActionResult Upload()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Upload(IFormFile file)//單檔上傳
        {


            using (var fileStream = new FileStream(Path.Combine(_dir, "file.png"), FileMode.Create, FileAccess.Write))
            {
                file.CopyTo(fileStream);
            }
            return RedirectToAction("Upload");
        }

        public IActionResult MulitipleFile(IEnumerable<IFormFile> files)//多檔上傳
        {
            int i = 0;
            foreach (var file in files)
            {
                using (var fileStream = new FileStream(Path.Combine(_dir, $"file{i++}.png"), FileMode.Create, FileAccess.Write))//執行一次i++
                {
                    file.CopyTo(fileStream);
                }
            }
            return RedirectToAction("Upload");
        }

        public IActionResult Index()
        {

            return View();
        }
    }
}
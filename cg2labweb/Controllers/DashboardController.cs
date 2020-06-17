using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using infra.Models;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;

namespace prjcg2lab.Controllers
{
    public class DashboardController : Controller
    {
        private IWebHostEnvironment _env;
        private string _dir;
        public DashboardController(IWebHostEnvironment env)
        {
            _env = env;
            _dir = env.ContentRootPath+ "/wwwroot/Mt/pdf/hank's";
        }
        // GET: Dashboard
        public IActionResult Dashboard()
        {
            return View();
        }
        
        public IActionResult UpdatePaper()
        {
            var i = 1;
            List<Research> rsl = new List<Research>();
            DirectoryInfo dir = new DirectoryInfo("wwwroot/Mt/pdf/hank's");
            FileInfo[] finfo = dir.GetFiles();
            foreach (FileInfo item in finfo)
            {
                //FileInfo fi=new FileInfo(FileCollection )

                rsl.Add(new Research()
                {
                    id=i,
                    fileName = item.Name,
                    justName = Path.GetFileNameWithoutExtension(item.FullName)

                });
                i++;
                //[C#] 幾個常用的取路徑及檔名的方法
                //ref:https://charleslin74.pixnet.net/blog/post/459749485-%5Bc%23%5D-%E5%B9%BE%E5%80%8B%E5%B8%B8%E7%94%A8%E7%9A%84%E5%8F%96%E8%B7%AF%E5%BE%91%E5%8F%8A%E6%AA%94%E5%90%8D%E7%9A%84%E6%96%B9%E6%B3%95
            }
            return View(rsl);
        }
        [HttpPost]
        public IActionResult UpdatePaper(IEnumerable<IFormFile> files)
        {
            foreach(var item in files)
            {
                using (var fileStream = new FileStream(Path.Combine(_dir, item.FileName), FileMode.Create, FileAccess.Write))
                {
                    item.CopyTo(fileStream);
                }
            }
            return RedirectToAction("UpdatePaper");
        }
        public IActionResult Delete(string fileName)
        {
            System.IO.File.Delete(@"wwwroot/Mt/pdf/hank's/"+fileName);
            return RedirectToAction("UpdatePaper");
        }
    }
}
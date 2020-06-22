using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using infra.Models;
using Service;
using infra.ViewModels;

namespace cg2labweb.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Hank()
        {
            List<Research> rsl = new List<Research>();
            DirectoryInfo dir = new DirectoryInfo("wwwroot/Mt/pdf/hank's");
            FileInfo[] finfo = dir.GetFiles();
            foreach (FileInfo item in finfo)
            {
                //FileInfo fi=new FileInfo(FileCollection )

                rsl.Add(new Research()
                {
                    fileName = item.Name,
                    justName = Path.GetFileNameWithoutExtension(item.FullName)

                });
                //[C#] 幾個常用的取路徑及檔名的方法
                //ref:https://charleslin74.pixnet.net/blog/post/459749485-%5Bc%23%5D-%E5%B9%BE%E5%80%8B%E5%B8%B8%E7%94%A8%E7%9A%84%E5%8F%96%E8%B7%AF%E5%BE%91%E5%8F%8A%E6%AA%94%E5%90%8D%E7%9A%84%E6%96%B9%E6%B3%95
            }
            return View(rsl);
        }
        public IActionResult Institute()
        {
            var mpV = new List<ViewMasterPaper>();
            using (var content = new ContextFactory().dbContext())
            {
                var query = from q in content.MasterPapers
                            orderby q.dateTime descending, q.Id ascending
                            where q.Id != 0
                            select new ViewMasterPaper
                            {
                                Id = q.Id,
                                dateTime = q.dateTime,
                                FileName = q.FileName,
                                FilePath = q.FilePath,
                                FileFullName = q.FileFullName,
                                MasterName = q.MasterName
                            };

                if (query.Any())
                {
                    mpV = query.ToList();
                }
                //var result = query.ToList();
                //foreach(var item in result)
                //{
                //    mpV.Add(new ViewMasterPaper
                //    {
                //        Id=item.Id,
                //        dateTime=item.dateTime,
                //        FileName=item.FileName,
                //        FilePath=item.FilePath,
                //        FileFullName=item.FileFullName,
                //        MasterName=item.MasterName
                //    });
                //}
            }
            return View(mpV);
        }

        public IActionResult Device()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Reseach()
        {
            List<Research> rsl = new List<Research>();
            DirectoryInfo dir = new DirectoryInfo("wwwroot/Mt/img/ImgPassReseach");
            FileInfo[] finfo = dir.GetFiles();
            foreach (FileInfo item in finfo)
            {
                //FileInfo fi=new FileInfo(FileCollection )

                rsl.Add(new Research()
                {
                    fileName = item.Name,
                    justName = Path.GetFileNameWithoutExtension(item.FullName)

                });
                //[C#] 幾個常用的取路徑及檔名的方法
                //ref:https://charleslin74.pixnet.net/blog/post/459749485-%5Bc%23%5D-%E5%B9%BE%E5%80%8B%E5%B8%B8%E7%94%A8%E7%9A%84%E5%8F%96%E8%B7%AF%E5%BE%91%E5%8F%8A%E6%AA%94%E5%90%8D%E7%9A%84%E6%96%B9%E6%B3%95
            }
            return View(rsl);
        }
        public IActionResult UndergraduateStudents()
        {
            var VUSW = new List<ViewUndergraduateStudentsWork>();
            using (var content = new ContextFactory().dbContext())
            {
                var query = from q in content.undergraduateStudentsWorks
                            orderby q.dateTime descending, q.Id ascending
                            where q.Id != 0
                            select new ViewUndergraduateStudentsWork
                            {
                                Id = q.Id,
                                dateTime = q.dateTime,
                                teammate = q.teammate,
                                topic = q.topic,
                                youtubeId = q.youtubeId,
                                
                            };

                if (query.Any())
                {
                    
                    VUSW= query.ToList();
                }
                //var result = query.ToList();
                //foreach(var item in result)
                //{
                //    mpV.Add(new ViewMasterPaper
                //    {
                //        Id=item.Id,
                //        dateTime=item.dateTime,
                //        FileName=item.FileName,
                //        FilePath=item.FilePath,
                //        FileFullName=item.FileFullName,
                //        MasterName=item.MasterName
                //    });
                //}
            }
            return View(VUSW);
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

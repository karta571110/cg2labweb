using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using infra.Models;
using infra.ViewModels;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using Service;
using System.Diagnostics;
using MySqlX.XDevAPI.Common;

namespace prjcg2lab.Controllers
{
    public class DashboardController : Controller
    {

        private IWebHostEnvironment _env;
        private string _dir;
        public DashboardController(IWebHostEnvironment env)
        {
            _env = env;
            _dir = env.ContentRootPath ;
        }
        // GET: Dashboard
        public IActionResult Dashboard()
        {
            
            //try
            //{
            //    var cf = new ContextFactory().dbContext();
            //    cf.Members.Add(new Member
            //    {

            //        Account = "ASdasd",
            //        Password = "cxvvcb"
            //    });
            //    cf.SaveChanges();
            //    //Debug.WriteLine("11111111111111");
            //}
            //catch(Exception ex)
            //{
            //    Debug.WriteLine(ex.Message);
            //}
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
                //Debug.WriteLine(item.FullName);
                rsl.Add(new Research()
                {
                    id = i,
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
            foreach (var item in files)
            {
                Debug.WriteLine(item.FileName);
                using (var fileStream = new FileStream(Path.Combine(_dir + "/wwwroot/Mt/pdf/hank's", item.FileName), FileMode.Create, FileAccess.Write))
                {
                    item.CopyTo(fileStream);
                }
            }
            return RedirectToAction("UpdatePaper");
        }
        public IActionResult UpdateMasterPaper()
        {
            List<ViewMasterPaper> mpV = new List<ViewMasterPaper>();
            
            using (var content = new ContextFactory().dbContext())
            {
                var query = from q in content.MasterPapers
                            orderby q.dateTime descending,q.Id ascending
                            where q.Id!=0
                            select new ViewMasterPaper {
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
        [HttpPost]
        public IActionResult UpdateMasterPaper(string AuthorName,string topic,IFormFile MasterPdfFile)
        {
            if (!Directory.Exists(_dir + "/wwwroot/Mt/pdf/MasterDegree/"+ AuthorName))
            {
                Directory.CreateDirectory(_dir + "/wwwroot/Mt/pdf/MasterDegree/" + AuthorName);
            }           
            using(var content=new ContextFactory().dbContext())
            {
                var mp = new MasterPaper
                {
                    FilePath = "/wwwroot/Mt/pdf/MasterDegree/" + AuthorName+"/" + topic + ".pdf",
                    FileName = topic,
                    MasterName = AuthorName,
                    FileFullName = topic + ".pdf",
                    dateTime = DateTime.Now
                };
                using (var fileStream = new FileStream(Path.Combine(_dir+ "/wwwroot/Mt/pdf/MasterDegree/"+ AuthorName, topic + ".pdf"), FileMode.Create, FileAccess.Write))
                {
                    MasterPdfFile.CopyTo(fileStream);
                }
                content.MasterPapers.Add(mp);
                content.SaveChanges();
            }
            return RedirectToAction("UpdateMasterPaper");
        }
        public IActionResult DeleteHankPaper(string fileName)
        {
            System.IO.File.Delete(@"wwwroot/Mt/pdf/hank's/" + fileName);
            return RedirectToAction("UpdatePaper");
        }
        public IActionResult DeleteMasterPaper(string filePath)
        {
            System.IO.File.Delete(@_dir+filePath);
            using(var content = new ContextFactory().dbContext())
            {
                var query = from q in content.MasterPapers
                            where q.FilePath == filePath
                            select q;
                if (query.FirstOrDefault() != null)
                {
                    content.Remove(query.FirstOrDefault());
                    content.SaveChanges();
                }
                
            }
            return RedirectToAction("UpdateMasterPaper");
        }
    }
}
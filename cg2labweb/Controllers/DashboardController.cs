using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using infra.Models;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using Service;
using System.Diagnostics;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace prjcg2lab.Controllers
{
    public class DashboardController : Controller
    {

        private IWebHostEnvironment _env;
        private string _dir;
        public DashboardController(IWebHostEnvironment env)
        {
            _env = env;
            _dir = env.ContentRootPath + "/wwwroot/Mt/pdf/hank's";
        }


        /*
                  Databse  (table) --> Entiy Model   (DbSet<XXX>) 
                  ViewModel 


                ex: Research             (Entiy)
                    ResearchViewModel
           

                // AutoMapper   Research <-->  ResearchViewModel

                  

                 ResearchViewModel fromUi

                 var query = from q in contet.Resourch 
                             where q.id  ==  fromUI.id 
                             select ; 

                  if(querey.Any()){
                       var item = query.First();   //entiry 

                       item.XXX = fromUI.XXX ;
                       //...  skip...
  
                      contet.saveChange();
                  }




         */





        public IActionResult Insert()
        {
            IActionResult result = View();
            try
            {
                using (var content = new ContextFactory().dbContext())
                {

                    Research toDb = new Research()
                    {
                        fileName = "test1",
                        justName = "test2",
                    };

                    content.Researches.Add(toDb);
                    content.SaveChanges();

                }

            }
            catch (Exception exp)
            {
                //  you can using NLog for loging 
                Console.WriteLine(exp.ToString());

                //result = RedirectToAction()
                //throw;
            }
            return result;
        }



        public IActionResult Update()
        {
            IActionResult result = View();
            try
            {
                using (var content = new ContextFactory().dbContext())
                {

                    var query = from q in content.Researches
                                where q.id == 1
                                select q;

                    if (query.Any())
                    {
                        var fromDB = query.FirstOrDefault();
                        fromDB.fileName = "aaaaaaa";

                        content.SaveChanges();
                    }

                }

            }
            catch (Exception exp)
            {
                //  you can using NLog for loging 
                Console.WriteLine(exp.ToString());

                //result = RedirectToAction()
                //throw;
            }
            return result;
        }

        // GET: Dashboard
        public IActionResult Dashboard()
        {
            try
            {
                using (var content = new ContextFactory().dbContext())
                {
                    // Linq  
                    var query = from q in content.Researches
                                select q;
                    //  IQueryable <--- non yet connection 



                    //var q = content.Researches.Where(x => x.id == 1)
                    //                          .Select(x => x.fileName)
                    //                          .ToList();


                    if (query.Any())
                    {
                        var result = query.ToList();
                        // IEnumerable  <-- get the date from databse , 

                        Console.WriteLine(result.Count);
                    }
                }





                //var cf = new ContextFactory();

                //cf.dbContext().Members.Add(new Member
                //{

                //    Account = "ASdasd",
                //    Password = "cxvvcb"
                //});
                //cf.dbContext().SaveChanges();
                //Debug.WriteLine("11111111111111");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
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
                using (var fileStream = new FileStream(Path.Combine(_dir, item.FileName), FileMode.Create, FileAccess.Write))
                {
                    item.CopyTo(fileStream);
                }
            }
            return RedirectToAction("UpdatePaper");
        }
        public IActionResult Delete(string fileName)
        {
            System.IO.File.Delete(@"wwwroot/Mt/pdf/hank's/" + fileName);
            return RedirectToAction("UpdatePaper");
        }
    }
}
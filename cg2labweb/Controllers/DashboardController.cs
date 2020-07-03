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
        public IActionResult Dashboard() => View();
        //{

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
        // return View();
        //}
        #region 專題生成果
        public IActionResult ViewUndergraduateStudentsWork()
        {
            
           var viewUndergraduateStudentsWorks = new List<ViewUndergraduateStudentsWork>();

            using (var content = new ContextFactory().dbContext())
            {
                var query = from q in content.undergraduateStudentsWorks
                            orderby q.dateTime descending, q.Id ascending
                            where q.Id != 0
                            select new ViewUndergraduateStudentsWork
                            {
                                Id = q.Id,
                                dateTime = q.dateTime,
                                googleDriveURL = q.googleDriveURL,
                                teammate = q.teammate,
                                topic = q.topic,
                                youtubeId = q.youtubeId,
                                youtubeURL=q.youtubeURL,
                                updaterName=q.updaterName
                            };

                if (query.Any())
                {
                    viewUndergraduateStudentsWorks = query.ToList();
                }
                
            }
            return View(viewUndergraduateStudentsWorks);
            
        }
        public IActionResult UpdateUndergraduateStudentsWork() => View();              
        [HttpPost]
        public IActionResult UpdateUndergraduateStudentsWork(ViewUndergraduateStudentsWork undergraduateStudentsWork)// string teammate, string topic,string youtubeURL,string googleDrive)
        {
            if (ModelState.IsValid)
            {
                string dealYoutubeId()
                {
                    var toRemove = "https://www.youtube.com/watch?v=";
                    var Result = undergraduateStudentsWork.youtubeURL.Replace(toRemove, "");
                    if (Result.Contains("&"))
                    {
                        Result = Result.Remove(Result.IndexOf("&"));
                        //Remove用法 ref:https://docs.microsoft.com/zh-tw/dotnet/api/system.string.remove?view=netcore-3.1
                        //IndexOf用法 ref:http://a-jau.blogspot.com/2012/01/cstringindexoflastindexofsubstringsplit.html
                    }
                    return Result;
                }
                using (var content = new ContextFactory().dbContext())
                {
                    var undergraduateStudents = new UndergraduateStudentsWork
                    {
                        teammate = undergraduateStudentsWork.teammate,
                        topic = undergraduateStudentsWork.topic,
                        youtubeURL = undergraduateStudentsWork.youtubeURL,
                        youtubeId = dealYoutubeId(),
                        googleDriveURL = undergraduateStudentsWork.googleDriveURL,
                        dateTime = DateTime.Now
                    };

                    content.undergraduateStudentsWorks.Add(undergraduateStudents);
                    content.SaveChanges();
                    return RedirectToAction("ViewUndergraduateStudentsWork");
                }
            }
            return View(undergraduateStudentsWork);
        }
        public IActionResult DeleteUndergraduateStudentsWork(int id)
        {
            using (var content = new ContextFactory().dbContext())
            {
                var query = from q in content.undergraduateStudentsWorks
                            where q.Id == id
                            select q;
                if (query.FirstOrDefault() != null)
                {
                    content.Remove(query.FirstOrDefault());
                    content.SaveChanges();
                }

            }
            return RedirectToAction("UpdateUndergraduateStudentsWork");
        }
        #endregion
        #region 碩士論文
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
        
        public IActionResult DeleteMasterPaper(string filePath,int id)
        {
            System.IO.File.Delete(@_dir+filePath);
            using(var content = new ContextFactory().dbContext())
            {
                var query = from q in content.MasterPapers
                            where q.Id == id
                            select q;
                if (query.FirstOrDefault() != null)
                {
                    content.Remove(query.FirstOrDefault());
                    content.SaveChanges();
                }
                
            }
            return RedirectToAction("UpdateMasterPaper");
        }
        #endregion
        #region Hank論文
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
        public IActionResult DeleteHankPaper(string fileName)
        {
            System.IO.File.Delete(@"wwwroot/Mt/pdf/hank's/" + fileName);
            return RedirectToAction("UpdatePaper");
        }
        #endregion
        #region 期刊論文
        public IActionResult ViewJournalPapersList()
        {

            var viewHankPageJournalPapers = new List<ViewHankPageJournalPaper>();

            using (var content = new ContextFactory().dbContext())
            {
                var query = from q in content.HankPageJournalPapers
                            orderby q.id
                            where q.id != 0
                            select new ViewHankPageJournalPaper
                            {
                                id = q.id,
                                JournalPaper = q.JournalPaper
                            };

                if (query.Any())
                {
                    viewHankPageJournalPapers = query.ToList();
                }

            }
            return View(viewHankPageJournalPapers);

        }
        public IActionResult JournalPapersList() => View();
        [HttpPost]
        public IActionResult JournalPapersList(ViewHankPageJournalPaper hankPageJournalPaper)
        {
            if (ModelState.IsValid)
            {
                ViewHankPageJournalPaper hpj = hankPageJournalPaper;

                using (var content = new ContextFactory().dbContext())
                {
                    var HankPageJournalPaper = new HankPageJournalPaper()
                    {
                        JournalPaper = hpj.JournalPaper
                    };
                    content.HankPageJournalPapers.Add(HankPageJournalPaper);
                    content.SaveChanges();
                    return RedirectToAction("JournalPapersList");
                }
            }
            return View(hankPageJournalPaper);
        }
        public IActionResult DeleteJournalPapers(int id)
        {
            using (var content = new ContextFactory().dbContext())
            {
                var query = from q in content.HankPageJournalPapers
                            where q.id == id
                            select q;
                if (query.FirstOrDefault() != null)
                {
                    content.Remove(query.FirstOrDefault());
                    content.SaveChanges();
                }

            }
            return RedirectToAction("ViewJournalPapersList");
        }
        #endregion
        #region 研討會論文       
        public IActionResult ViewSeminarPapers()
        {

            var viewHankPageSeminarPapers = new List<ViewHankPageSeminarPaper>();

            using (var content = new ContextFactory().dbContext())
            {
                var query = from q in content.HankPageSeminarPapers
                            orderby q.Id
                            where q.Id != 0
                            select new ViewHankPageSeminarPaper
                            {
                                Id = q.Id,
                                SeminarPaper=q.SeminarPaper
                            };

                if (query.Any())
                {
                    viewHankPageSeminarPapers = query.ToList();
                }

            }
            return View(viewHankPageSeminarPapers);

        }
        public IActionResult SeminarPapers() => View();
       [HttpPost]
        public IActionResult SeminarPapers(ViewHankPageSeminarPaper viewHankPageSeminarPaper)
        {
            if (ModelState.IsValid)
            {
                using (var content = new ContextFactory().dbContext())
                {
                    var hankPageSeminarPaper = new HankPageSeminarPaper
                    {
                        SeminarPaper=viewHankPageSeminarPaper.SeminarPaper
                    };

                    content.HankPageSeminarPapers.Add(hankPageSeminarPaper);
                    content.SaveChanges();
                    return RedirectToAction("SeminarPapers");
                }
            }
            return View(viewHankPageSeminarPaper);
        }
        public IActionResult DeleteSeminarPapers(int id)
        {
            using (var content = new ContextFactory().dbContext())
            {
                var query = from q in content.HankPageSeminarPapers
                            where q.Id == id
                            select q;
                if (query.FirstOrDefault() != null)
                {
                    content.Remove(query.FirstOrDefault());
                    content.SaveChanges();
                }

            }
            return RedirectToAction("ViewSeminarPapers");
        }
        #endregion
    }
}
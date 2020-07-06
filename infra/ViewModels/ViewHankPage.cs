using infra.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace infra.ViewModels
{

    public class ViewHankPage
    {

        public List<ViewHankPageJournalPaper> JournalPapers { get; set; }
        public List<Research> researches { get; set; }
        public List<ViewHankPageSeminarPaper> viewHankPageSeminarPapers { get; set; }
        public List<ViewHankPageHonor> viewHankPageHonors { get; set; }
        public List<ViewHankPageProject> viewHankPageProjects { get; set; }
        public List<ViewIndustryResearch> ViewIndustryResearches { get; set; }
    }
}

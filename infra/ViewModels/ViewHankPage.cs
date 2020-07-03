using infra.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace infra.ViewModels
{

    public class ViewHankPage
    {

        public string JournalPaper { get; set; }
        public Research research { get; set; }
        public ViewHankPageSeminarPaper ViewHankPageSeminarPaper { get; set; }
        public ViewHankPageHonor ViewHankPageHonor { get; set; }
        public ViewHankPageProject ViewHankPageProject { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace infra.ViewModels
{
    public class ViewHankPageJournalPaper
    {
        public int id { get; set; }
        [Required]
        public string JournalPaper { get; set; }
    }
}

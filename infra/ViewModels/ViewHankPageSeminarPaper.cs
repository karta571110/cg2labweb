using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace infra.ViewModels
{
   public class ViewHankPageSeminarPaper
    {
        public int Id { get; set; }
        [Required]
        public string SeminarPaper { get; set; }
    }
}

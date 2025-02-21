﻿using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace infra.ViewModels
{
    public class ViewMasterPaper
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string MasterName { get; set; }
        public string FilePath { get; set; }
        [Required]
        public string FileName { get; set; }
        
        public string FileFullName { get; set; }
        public DateTime dateTime { get; set; }
    }
}

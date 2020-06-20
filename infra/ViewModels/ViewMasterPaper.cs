using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace infra.ViewModels
{
    public class ViewMasterPaper
    {
        [Key]
        public int Id { get; set; }
        public string MasterName { get; set; }
        public string FilePath { get; set; }
        public string FileName { get; set; }
        public string FileFullName { get; set; }
        public DateTime dateTime { get; set; }
    }
}

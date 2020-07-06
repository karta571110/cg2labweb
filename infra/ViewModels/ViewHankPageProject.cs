using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace infra.ViewModels
{
    public class ViewHankPageProject
    {
        public int id { get; set; }
        [Required]
        public int schoolYear { get; set; }
        [Required]
        public string projectName { get; set; }
        [Required]
        public string projectTopice { get; set; }
    }
}

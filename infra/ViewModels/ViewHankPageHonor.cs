using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace infra.ViewModels
{
   public class ViewHankPageHonor
    {
        public int id { get; set; }
        [Required]
        public string schoolYear { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string DoWhat { get; set; }
        [Required]
        public string Award { get; set; }
    }
}

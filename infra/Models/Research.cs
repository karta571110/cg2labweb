using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace infra.Models
{

    public class Research
    {
        [Key]
        public int id { get; set; }

        public string fileName { get; set; }

        public string justName { get; set; }
    }
}
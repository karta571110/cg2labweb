using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace cg2labweb.Models
{

    public class Research
    {
        [Key]
        public int key { get; set; }
        public string fileName { get; set; }

        public string justName { get; set; }
    }
}
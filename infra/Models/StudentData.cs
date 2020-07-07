using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace infra.Models
{
    public class StudentData
    {
        [Key]
        public int id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Studentid { get; set; }

        public string Status { get; set; }
    }
}

﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace infra.Models
{
    public class Member
    {
        [Key]
        public int Id { get; set; }
        public string Account { get; set; }
        public string Password { get; set; }
    }
}

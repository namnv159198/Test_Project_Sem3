﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Test_Project_IdentityMVC.Models
{
    public class Feedback
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public int? Answer { get; set; }
        [StringLength(500)]
        public string Comment { get; set; }
        [StringLength(100)]
        public string Fullname { get; set; }
        [StringLength(255)]
        public string Email { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Test_Project_IdentityMVC.Models
{
    public class FeedbackViewModel
    {
        public string Comment { get; set; }
        public string  Fullname { get; set; }
        public string Email { get; set; }
        public int? Select { get; set; }
        public List<Answer> Answers { get; set; }
    }
}
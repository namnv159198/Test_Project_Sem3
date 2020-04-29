using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Test_Project_IdentityMVC.Models
{
    public class User
    {
        public User(System.Security.Principal.IPrincipal user) { }
        public User(ApplicationUser  user)
        {
            Id = user.Id;
            UserName = user.UserName;
        }
        public string Id { get; set; }
        public string UserName { get; set; }
        public GenderEnum Gender { get; set; }
        public enum GenderEnum
        {
            Male = 0,
            Female = 1,
            Other = 2
        }
        public int PhoneNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }     
        public string Address { get; set; }     
        public string Birthday { get; set; }
    }
    }


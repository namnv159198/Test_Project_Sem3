using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Test_Project_IdentityMVC.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {

        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Display(Name = "Address")]
        public string Address { get; set; }
        [Display(Name = "Birthday")]
        public DateTime? BirthdayAt { get; set; }
        [Display(Name = "Gender")]
        public GenderEnum Gender { get; set; }
        public enum GenderEnum
        {
            Male = 0,
            Female = 1,
            Other = 2
        }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public ApplicationUser()
        {
            this.CreatedDate = DateTime.Now;
        }
        [Display(Name = "Avatar")]
        public String Avatar { get; set; }
        [Display(Name = "Active")]
        public ActiveEnum Active { get; set; }
        public enum ActiveEnum
        {
            Active = 0,
            Banned = 1,

        }
        [Display(Name = "Update By")]
        public string UpdateById { get; set; }
        [ForeignKey("UpdateById")]
        public virtual ApplicationUser UpdatedBy { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationRole : IdentityRole
    {
        public ApplicationRole() : base() { }
        public ApplicationRole(string roleName) : base(roleName) { }
    }
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<Test_Project_IdentityMVC.Models.Product> Products { get; set; }


        public System.Data.Entity.DbSet<Test_Project_IdentityMVC.Models.Product2> Product2 { get; set; }
       

    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Test_Project_IdentityMVC.Models
{
    public class Feedback
    {
        public int Id { get; set; }
    
        public String Subject { get; set; }
      
        public string Content { get; set; }
        [StringLength(100)]
     
        public string Name { get; set; }
        [StringLength(255)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public DateTime? CreateAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public DateTime? HandleAt { get; set; }
        [Display(Name = "Status")]
        [NotMapped]
        public EnumStatus Status { get; set; }
        public enum EnumStatus
        {
            New = 0,
            Processed = 1,
            Delete = -1
        }
        [Display(Name = "Handle By")]
        public string UpdateById { get; set; }
        [ForeignKey("UpdateById")]
        public virtual ApplicationUser HandleBy { get; set; }
        [Display(Name = "Delete By")]
        public String DeleteById { get; set; }
        [ForeignKey("DeleteById")]
        public virtual ApplicationUser DeleteBy { get; set; }
    }
}
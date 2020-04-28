using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Test_Project_IdentityMVC.Models
{
    public class EditProduct
    {
        [Key]
        public int Id { get; set; }
        public String Name { get; set; }
        public String Content { get; set; }
        public String Description { get; set; }
        public double Price { get; set; }
        public String Thumbnails { get; set; }
        [Display(Name = "Create At")]
        public DateTime? CreatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        [Display(Name = "Create By")]
        public String CreateById { get; set; }
        [ForeignKey("CreateById")]
        public virtual ApplicationUser CreateBy { get; set; }

        [Display(Name = "Update By")]
        public string UpdateById { get; set; }
        [ForeignKey("UpdateById")]
        public virtual ApplicationUser UpdateBy { get; set; }
        [Display(Name = "Delete By")]
        public String DeleteById { get; set; }
        [ForeignKey("DeleteById")]
        public virtual ApplicationUser DeleteBy { get; set; }


        [Display(Name = "Status")]
        public Product.EnumStatus Status { get; set; }
        public enum EnumStatus
        {
            Active = 0,
            DeActive = 1,
            Delete = -1
        }
      
        public string GetDefaultThumbnails()
        {
            if (this.Thumbnails != null && this.Thumbnails.Length > 0)
            {
                var arrayThumbnails = this.Thumbnails.Split(',');
                if (arrayThumbnails.Length > 0)
                {
                    return "https://res.cloudinary.com/namnguyen159198/" + arrayThumbnails[0];
                }

            }

            return
                "https://2.bp.blogspot.com/-muVbmju-gkA/Vir94NirTeI/AAAAAAAAT9c/VoHzHZzQmR4/s580/placeholder-image.jpg";
        }
        public string[] GetThumbnails()
        {
            if (this.Thumbnails != null && this.Thumbnails.Length > 0)
            {
                var arrayThumbnails = this.Thumbnails.Split(',');
                if (arrayThumbnails.Length > 0)
                {
                    return arrayThumbnails;
                }

            }

            return new string[0];
        }
    }
}
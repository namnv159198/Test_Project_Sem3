using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Test_Project_IdentityMVC.Models
{
    public class Product
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
        public EnumStatus Status { get; set; }
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
                var arrayThumbnails  = this.Thumbnails.Split(',');
                if (arrayThumbnails.Length > 0)
                {
                    return 
                        ConfigurationManager.AppSettings["CloudinaryPrefix"] + arrayThumbnails[0];
                }

            }

            return ConfigurationManager.AppSettings["ImageNull"];
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

            return new  string[0];
        }

        public string[] GetThumbnailIDs()
        {
            var idThumbnail = new List<string>();
            var thumbnails = GetThumbnails();
            foreach (var i in thumbnails)
            {
                // image/upload/v1587720852/trang-phuc-nakroth-bboy-cong-nghe-compressed_ewu3rb_qj7zct.jpg#81ad3dee47db0da23fae48523665b35024516448
                var SplittedThumbnails =   i.Split('/');
                // [image,   upload,  v1587720852,  trang-phuc-nakroth-bboy-cong-nghe-compressed_ewu3rb_qj7zct.jpg#81ad3dee47db0da23fae48523665b35024516448] = 4
                //   0    ,  1 ,       2 ,             3]
                if (SplittedThumbnails.Length != 4)
              {
                  continue;
              }
                //[trang-phuc-nakroth-bboy-cong-nghe-compressed_ewu3rb_qj7zct.jpg#81ad3dee47db0da23fae48523665b35024516448]
                idThumbnail.Add(SplittedThumbnails[3].Split('.')[0]) ;
                // [trang-phuc-nakroth-bboy-cong-nghe-compressed_ewu3rb_qj7zct , jpg#81ad3dee47db0da23fae48523665b35024516448]
                // id = trang-phuc-nakroth-bboy-cong-nghe-compressed_ewu3rb_qj7zct 

            }
            return idThumbnail.ToArray();
        }
    }
}
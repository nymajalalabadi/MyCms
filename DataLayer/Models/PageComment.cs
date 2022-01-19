using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class PageComment
    {
        [Key]
        public int CommentID { get; set; }


        [Display(Name = "خبر")]
        [Required(ErrorMessage = "لطفا عنوان گروه را وارد کنید")]
        public int PageID { get; set; }


        [Display(Name = "نام")]
        [Required(ErrorMessage = "لطفا عنوان گروه را وارد کنید")]
        public string Name  { get; set; }


        [Display(Name = "ایمیل")]
        [MaxLength(250)]
        public string Email { get; set; }


        [Display(Name = "سایت")]
        [MaxLength(250)]
        public string WebSite { get; set; }


        [Display(Name = "نظر")]
        [Required(ErrorMessage = "لطفا عنوان گروه را وارد کنید")]
        [MaxLength(550)]
        public string Comment { get; set; }


        [Display(Name = "تاریخ ثبت")]
        public DateTime CreateDate { get; set; }



        public Page Page { get; set; }


        public PageComment()
        {

        }
    }
}

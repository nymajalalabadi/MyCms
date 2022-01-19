using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace DataLayer
{
    public class Page
    {
        [Key]
        public int PageID { get; set; }


        [Display(Name = "گروه صفحه")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int GroupID { get; set; }


        [Display(Name = "عنوان ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(250)]
        public string Title { get; set; }


        [Display(Name = "توضیح مختصر")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(550)]
        [DataType(DataType.MultilineText)]
        public string ShortDescription { get; set; }


        [Display(Name = "متن")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [DataType(DataType.MultilineText)]
        
        public string Text { get; set; }


        [Display(Name = "بازدید")]
        public int Vist { get; set; }


        [Display(Name = "تصویر")]
        public string ImageName { get; set; }


        [Display(Name = "اسلایدر")]
        public bool ShowInslider { get; set; }


        [Display(Name = "کلمات کلیدی")]
        public string Tags { get; set; }


        [Display(Name = "تاریخ ایجاد")]
        [DisplayFormat(DataFormatString ="{0:yyyy/MM/dd}")]
        public DateTime CreateDate { get; set; }


        public virtual GroupPage GroupPage { get; set; }


        public virtual List<PageComment> PageComments { get; set; }



        public Page()
        {

        }
    }
}

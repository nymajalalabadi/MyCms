using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace DataLayer
{
    public class GroupPage
    {
        [Key]
        public int GroupID { get; set; }


        [Display(Name = "عنوان گروه")]
        [Required(ErrorMessage = "لطفا عنوان گروه را وارد کنید")]
        [MaxLength(250)]
        public string GroupTitle { get; set; }



        public virtual List<Page> Pages { set; get; }


        public GroupPage()
        {

        }
    }
}

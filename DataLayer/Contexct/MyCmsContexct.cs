using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class MyCmsContexct:DbContext
    {
        public DbSet<GroupPage> GroupPages { get; set; }



        public DbSet<Page> pages { get; set; }



        public DbSet<PageComment> PageComments { get; set; }

        public DbSet<AdminLogin> AdminLogins { get; set; }
    }
}

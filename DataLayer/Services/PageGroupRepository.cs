using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
     public class PageGroupRepository : IPageGroupRepository
    {
        private MyCmsContexct db;
        public PageGroupRepository(MyCmsContexct context)
        {
            this.db = context;
        }

        public IEnumerable<GroupPage> GetAllGroups()
        {
            return db.GroupPages;
        }


        public GroupPage GetGroupById(int groupid)
        {
            return db.GroupPages.Find(groupid);

        }


        public bool insertgroup(GroupPage groupPage)
        {
            try
            {
                db.GroupPages.Add(groupPage);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool UpdateGroup(GroupPage groupPage)
        {
            try
            {
                db.Entry(groupPage).State = EntityState.Modified;
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }


        public bool DeleteGroup(GroupPage groupPage)
        {
            try
            {
                db.Entry(groupPage).State = EntityState.Deleted;
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }


        public bool DeleteGroup(int groupId)
        {
            try
            {
                var group = GetGroupById(groupId);
                DeleteGroup(group);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public void save()

        {
            db.SaveChanges();

        }

        public void Dispose()
        {
            db.Dispose();
        }

        public IEnumerable<ShowGroupViewModel> GetGroupView()
        {
            return db.GroupPages.Select(g => new ShowGroupViewModel()
            {
                GroupID = g.GroupID,
                GroupTitle = g.GroupTitle,
                PageCount = g.Pages.Count
            });
        }
    }
}

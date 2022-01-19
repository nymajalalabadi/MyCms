using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class PageRepository : IPageRepository
    {
        private MyCmsContexct db;
        public PageRepository(MyCmsContexct context)
        {
            this.db = context;
        }



        public IEnumerable<Page> GetAllPage()
        {
            return db.pages;
        }


        public Page GetPageById(int pageid)
        {
            return db.pages.Find(pageid);
        }


        public bool insertPage(Page page)
        {
            try
            {
                db.pages.Add(page);
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }


        public bool UpdatePage(Page page)
        {
            try
            {
                db.Entry(page).State = EntityState.Modified;
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }


        public bool DeletePage(Page page)
        {
            try
            {
                db.Entry(page).State = EntityState.Deleted;
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }


        public bool DeletePage(int pageid)
        {
            try
            {
                var page = GetPageById(pageid);
                DeletePage(page);
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
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

        public IEnumerable<Page> TopNew(int take = 4)
        {
            return db.pages.OrderByDescending(p => p.Vist).Take(take);
        }

        public IEnumerable<Page> PagesInSlider()
        {

            return db.pages.Where(p => p.ShowInslider == true);

        }

        public IEnumerable<Page> LastNews(int take = 4)
        {
            return db.pages.OrderByDescending(p => p.CreateDate).Take(take);
        }

        public IEnumerable<Page> ShowPageByGroupId(int groupId)
        {
            return db.pages.Where(p => p.GroupID == groupId);
        }

        public IEnumerable<Page> SearchPage(string search)
        {
                return
                    db.pages.Where(
                        p =>
                            p.Title.Contains(search) || p.ShortDescription.Contains(search) || p.Tags.Contains(search) ||
                            p.Text.Contains(search)).Distinct();
            
        }
    }
}

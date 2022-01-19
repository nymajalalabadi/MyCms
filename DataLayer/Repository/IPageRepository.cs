using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public interface IPageRepository:IDisposable
    {
        IEnumerable<Page> GetAllPage();

        Page GetPageById(int pageid);

        bool insertPage(Page page);

        bool UpdatePage(Page page);

        bool DeletePage(Page page);

        bool DeletePage(int pageid);

        void save();

        IEnumerable<Page> TopNew(int take=4);

        IEnumerable<Page> PagesInSlider();

        IEnumerable<Page> LastNews(int take = 4);

        IEnumerable<Page> ShowPageByGroupId(int groupId);

        IEnumerable<Page> SearchPage(string search);


    }
}

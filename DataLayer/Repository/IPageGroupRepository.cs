using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
   public interface IPageGroupRepository:IDisposable
    {
        IEnumerable<GroupPage> GetAllGroups();

        GroupPage GetGroupById(int groupid);

        bool insertgroup(GroupPage groupPage);

        bool UpdateGroup(GroupPage groupPage);

        bool DeleteGroup(GroupPage groupPage);

        bool DeleteGroup(int groupId);

        void save();


        IEnumerable<ShowGroupViewModel> GetGroupView();
    }
}

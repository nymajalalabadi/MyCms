using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DataLayer;

namespace MyCms3.Areas.Admin.Controllers
{
    [Authorize]
    public class GroupPagesController : Controller
    {
        private IPageGroupRepository pageGroupRepository;

        private MyCmsContexct db = new MyCmsContexct();

        public GroupPagesController()
        {
            pageGroupRepository = new PageGroupRepository(db);
        }
       

        // GET: Admin/GroupPages
        public ActionResult Index()
        {
            return View(pageGroupRepository.GetAllGroups()) ;
        }

        // GET: Admin/GroupPages/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GroupPage groupPage = pageGroupRepository.GetGroupById(id.Value);
            if (groupPage == null)
            {
                return HttpNotFound();
            }
            return View(groupPage);
        }

        // GET: Admin/GroupPages/Create
        public ActionResult Create()
        {
            return PartialView();
        }

        // POST: Admin/GroupPages/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GroupID,GroupTitle")] GroupPage groupPage)
        {
            if (ModelState.IsValid)
            {
                pageGroupRepository.insertgroup(groupPage);
                pageGroupRepository.save();
                return RedirectToAction("Index");
            }

            return View(groupPage);
        }

        // GET: Admin/GroupPages/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GroupPage groupPage = pageGroupRepository.GetGroupById(id.Value);
            if (groupPage == null)
            {
                return HttpNotFound();
            }
            return PartialView(groupPage);
        }

        // POST: Admin/GroupPages/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GroupID,GroupTitle")] GroupPage groupPage)
        {
            if (ModelState.IsValid)
            {
                pageGroupRepository.UpdateGroup(groupPage);
                pageGroupRepository.save();
                return RedirectToAction("Index");
            }
            return View(groupPage);
        }

        // GET: Admin/GroupPages/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GroupPage groupPage =pageGroupRepository.GetGroupById(id.Value);
            if (groupPage == null)
            {
                return HttpNotFound();
            }
            return PartialView(groupPage);
        }

        // POST: Admin/GroupPages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            pageGroupRepository.DeleteGroup(id);
            pageGroupRepository.save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                pageGroupRepository.Dispose();
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

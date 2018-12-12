using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Project2.DAL;
using Project2.Models;

namespace Project2.Controllers
{
    [Authorize]
    public class MissionQuestionsController : Controller
    {
        private Project2Context db = new Project2Context();

        // GET: MissionQuestions
        public ActionResult Index()
        {
            var missionQuestions = db.MissionQuestions.Include(m => m.Missions);
            return View(missionQuestions.ToList());
        }

        [HttpPost]
        public ActionResult Index(Missions myMission)
        {
            var missionQuestions = db.MissionQuestions.Include(m => m.Missions);
            var MissionsQuery = db.Database.SqlQuery<Missions>("SELECT * FROM MISSIONS WHERE MissionName = " + myMission.missionName);
            ViewBag.MissionOutput = MissionsQuery;
            return View(missionQuestions.ToList());
        }

        // GET: MissionQuestions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MissionQuestions missionQuestions = db.MissionQuestions.Find(id);
            if (missionQuestions == null)
            {
                return HttpNotFound();
            }
            return View(missionQuestions);
        }

        // GET: MissionQuestions/Create
        public ActionResult Create()
        {
            ViewBag.missionID = new SelectList(db.Missions, "missionID", "missionName");
            return View();
        }

        // POST: MissionQuestions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "missionquestionID,question,answer,missionID")] MissionQuestions missionQuestions)
        {
            if (ModelState.IsValid)
            {
                db.MissionQuestions.Add(missionQuestions);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.missionID = new SelectList(db.Missions, "missionID", "missionName", missionQuestions.missionID);
            return View(missionQuestions);
        }

        // GET: MissionQuestions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MissionQuestions missionQuestions = db.MissionQuestions.Find(id);
            if (missionQuestions == null)
            {
                return HttpNotFound();
            }
            ViewBag.missionID = new SelectList(db.Missions, "missionID", "missionName", missionQuestions.missionID);
            return View(missionQuestions);
        }

        // POST: MissionQuestions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "missionquestionID,question,answer,missionID")] MissionQuestions missionQuestions)
        {
            if (ModelState.IsValid)
            {
                db.Entry(missionQuestions).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.missionID = new SelectList(db.Missions, "missionID", "missionName", missionQuestions.missionID);
            return View(missionQuestions);
        }

        // GET: MissionQuestions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MissionQuestions missionQuestions = db.MissionQuestions.Find(id);
            if (missionQuestions == null)
            {
                return HttpNotFound();
            }
            return View(missionQuestions);
        }

        // POST: MissionQuestions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MissionQuestions missionQuestions = db.MissionQuestions.Find(id);
            db.MissionQuestions.Remove(missionQuestions);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

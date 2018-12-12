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
            //var MissionsQuery = db.Database.SqlQuery<Missions>("SELECT * FROM MISSIONS WHERE MissionName = " + myMission.missionName);
            //ViewBag.MissionOutput = MissionsQuery;

            if (myMission.missionName == "Moscow")
            {
                ViewBag.Mission = "<br><br><b>Mission Name:</b> Russia Moscow Mission<br>" +
                "<b>Mission President’s Name:</b> Jeff McGhie <br>" +
                "<b>Mission Address:</b> Muravskaya Ulitsa, 1 D, Floor 3<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Moscow<br>" +
                "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Moscow 125310 Russia <br>" +
                "<b>Language:</b> Russian <br>" +
                "<b>Climate:</b> Really Cold <br>" +
                "<b>Dominate Religion:</b> Russian Orthodox <br><br>";
                ViewBag.Image = Url.Content("~/Content/images/russia_flag.jpg");
            }
            else if (myMission.missionName == "Portland")
            {
                ViewBag.Mission = "<br><br><b>Mission Name:</b> Oregon Portland Mission <br>" +
                        "<b>Mission President’s Name:</b> Jonathan W. Bullen  <br>" +
                        "<b>Mission Address:</b> 1400 NW Compton Dr Ste 250<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Beaverton OR 97006<br>" +
                        "<b>Languages:</b> English, Spanish <br>" +
                        "<b>Climate:</b> Very Wet, Slightly Humid <br>" +
                        "<b>Dominate Religion:</b> Christian (Evangelical, Catholic)<br><br>";
                ViewBag.Image = Url.Content("~/Content/images/FlagOregon.png");
            }
            else if (myMission.missionName == "Barcelona")
            {
                ViewBag.Mission = "<br><br><b>Mission Name:</b> Spain Barcelona Mission<br>" +
                          "<b>Mission President’s Name:</b> Craig David Galli<br>" +
                          "<b>Mission Address:</b> C/ Calatrava 10-12, bajos<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;08017 Barcelona ESPA&#209;A<br>" +
                          "<b>Language:</b> Spanish<br>" +
                          "<b>Climate:</b> Hot, Humid Summers and Rainy Winters<br>" +
                          "<b>Dominate Religion:</b> Catholic<br><br>";
                ViewBag.Image = Url.Content("~/Content/images/spain.jpg");
            }

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

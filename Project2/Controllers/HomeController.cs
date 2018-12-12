using Project2.DAL;
using Project2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Project2.Controllers
{
    [RequireHttps]
    public class HomeController : Controller
    {
        private Project2Context db = new Project2Context();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


        [Authorize]
        public ActionResult MissionsFAQ()
        {
            ViewBag.Message = "Your mission FAQ page.";

            return View();
        }

        [HttpGet]
        [Authorize]
        public ActionResult Missions()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public ActionResult Missions(Missions myMission)
        {
            if (ModelState.IsValid)
            {               
                    var MissionsQuery = db.Database.SqlQuery<Missions>("SELECT * FROM MISSIONS WHERE MissionName = " + myMission.missionName);
                    ViewBag.MissionOutput = MissionsQuery;
                    return RedirectToAction("Index", "MissionQuestions");
            }
            else
            {
                //Validation Error
                return View();
            }
        }
    }
}
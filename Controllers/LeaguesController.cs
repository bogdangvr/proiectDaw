using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using fantasyF1.Models;

namespace fantasyF1.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class LeaguesController : Controller
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();
        // GET: /leagues/index
        [HttpGet]

        [AllowAnonymous]
        public ActionResult Index()
        {
            var leagues = _context.Leagues.OrderBy(x => x.Name).ToList();

            ViewBag.Leagues = leagues;

            return View();
        }

        // GET: /leagues/create
        [HttpGet]
        
        [AllowAnonymous]
        public ActionResult Create()
        {
            return View();
        }

        // POST: /leagues/create
        [HttpPost]
        public ActionResult Create(League league, String AllowedDriver, String AllowedTeam, String AllowedMotor)
        {
            try
            {
                var motor = _context.Motors.ToList();
                if (AllowedMotor != "")
                {
                    motor = _context.Motors.Where(x => x.Name == AllowedMotor).ToList();
                }
                var rosterList = _context.Rosters.ToList();
                if (motor.Count != 0 && AllowedMotor != "")
                {
                    league.AllowedMotor = (Motor)motor[0];
                    league.AllowedMotorId = ((Motor)motor[0]).MotorId;
                    rosterList = rosterList.Where(x => x.Motor.Name == AllowedMotor).ToList();
                }
                var team = _context.Teams.ToList();
                if (AllowedTeam != "")
                {
                    team = _context.Teams.Where(x => x.Name == AllowedTeam).ToList();
                }
                if (team.Count != 0 && AllowedTeam != "")
                {
                    league.AllowedTeam = (Team)team[0];
                    league.AllowedTeamId = ((Team)team[0]).TeamId;
                    rosterList = rosterList.Where(x => x.Motor.Name == AllowedTeam).ToList();
                }
                var driver = _context.Drivers.ToList();
                if (AllowedDriver != "")
                {
                    driver = _context.Drivers.Where(x => x.Name == AllowedDriver).ToList();
                }
                if (driver.Count != 0 && AllowedDriver != "")
                {
                    league.AllowedDriver = (Driver)driver[0];
                    league.AllowedDriverId = ((Driver)driver[0]).DriverId;
                    rosterList = rosterList.Where(x => x.Motor.Name == AllowedDriver).ToList();
                }
                league.Rosters = rosterList;

                _context.Leagues.Add(league);

                _context.SaveChanges();

                return RedirectToAction("Index", "Leagues");
            }
            catch (Exception e)
            {
                return Json(new { error = e.Message }, JsonRequestBehavior.AllowGet);
            }
            return View(league);
        }

        // GET: /leagues/edit/{id}
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var league = _context.Leagues.Find(id);

            if (league == null)
            {
                return HttpNotFound();
            }
            Update(id);
            return View(league);
        }


        // GET: /leagues/update
        [HttpGet]
        public ActionResult Update(int id)
        {
            var league = _context.Leagues.Find(id);
            try
            {
                var rosters = _context.Rosters.ToList();
                if (league.AllowedDriver != null)
                {
                    rosters = _context.Rosters.Where(x => x.Driver == league.AllowedDriver).ToList();
                }
                if (league.AllowedDriver != null)
                {
                    rosters = _context.Rosters.Where(x => x.Team == league.AllowedTeam).ToList();
                }
                if (league.AllowedDriver != null)
                {
                    rosters = _context.Rosters.Where(x => x.Motor == league.AllowedMotor).ToList();
                }
                league.Rosters = rosters;

                _context.SaveChanges();

                return RedirectToAction("Index", "Leagues");

            }
            catch (Exception e)
            {
                return Json(new { error_message = e.Message }, JsonRequestBehavior.AllowGet);
            }

            return View(league);
        }

        // GET: /leagues/details/{id}
        [HttpGet]
        [AllowAnonymous]
        public ActionResult Details(int id)
        {
            var league = _context.Leagues.Find(id);

            if (league == null)
            {
                return HttpNotFound();
            }

            return View(league);
        }

        // GET: /leagues/delete/{id}
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var league = _context.Leagues.Find(id);

            if (league == null)
            {
                return HttpNotFound();
            }

            _context.Leagues.Remove(league);

            _context.SaveChanges();

            return RedirectToAction("Index", "Leagues");
        }
    }
}
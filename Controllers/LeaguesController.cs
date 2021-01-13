using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using fantasyF1.Models;
using System.ComponentModel.DataAnnotations;

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
                    rosterList = rosterList.Where(x => x.Team.Name == AllowedTeam).ToList();
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
                    rosterList = rosterList.Where(x => x.Driver.Name == AllowedDriver).ToList();
                }
                league.Rosters = rosterList;
                league.CreatedTime = System.DateTime.Now;

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
                    rosters = rosters.Where(x => x.Driver == league.AllowedDriver).ToList();
                }
                if (league.AllowedTeam != null)
                {
                    rosters = rosters.Where(x => x.Team == league.AllowedTeam).ToList();
                }
                if (league.AllowedMotor != null)
                {
                    rosters = rosters.Where(x => x.Motor == league.AllowedMotor).ToList();
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

        // GET: /leagues/refresh
        [HttpGet]
        public ActionResult Refresh()
        {
            var leagues = _context.Leagues.ToList();
            try
            {
                foreach (League league in leagues)
                {
                    League newLeague = new League();
                    var rosters = _context.Rosters.ToList();
                    if (league.AllowedDriver != null)
                    {
                        rosters = rosters.Where(x => x.Driver == league.AllowedDriver).ToList();
                    }
                    if (league.AllowedTeam != null)
                    {
                        rosters = rosters.Where(x => x.Team == league.AllowedTeam).ToList();
                    }
                    if (league.AllowedMotor != null)
                    {
                        rosters = rosters.Where(x => x.Motor == league.AllowedMotor).ToList();
                    }
                    newLeague.AllowedDriver = league.AllowedDriver;
                    newLeague.AllowedDriverId = league.AllowedDriverId;
                    newLeague.AllowedMotor = league.AllowedMotor;
                    newLeague.AllowedMotorId = league.AllowedMotorId;
                    newLeague.AllowedTeam = league.AllowedTeam;
                    newLeague.AllowedTeamId = league.AllowedTeamId;
                    newLeague.Name = league.Name;
                    newLeague.Prize = league.Prize;
                    newLeague.Rosters = rosters;
                    newLeague.LeagueId = league.LeagueId-1;
                    var aux = _context.Leagues.ToList();
                    _context.Leagues.Add(newLeague);
                    var aux1 = _context.Leagues.ToList();
                    _context.Leagues.Remove(league);
                    _context.SaveChanges();
                    var aux2 = _context.Leagues.ToList();

                }

                _context.SaveChanges();

                return RedirectToAction("Index", "Leagues");

            }
            catch (Exception e)
            {
                return Json(new { error_message = e.Message }, JsonRequestBehavior.AllowGet);
            }

            return View(leagues);
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
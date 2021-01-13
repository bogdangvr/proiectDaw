using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using fantasyF1.Models;

namespace fantasyF1.Controllers
{
    public class RostersController : Controller
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();
        // GET: /rosters/index
        [HttpGet]

        [AllowAnonymous]
        public ActionResult Index()
        {
            var rosters = _context.Rosters.OrderByDescending(x => x.Points).ToList();

            ViewBag.Rosters = rosters;

            return View();
        }

        // GET: /rosters/create
        [HttpGet]
        [AllowAnonymous]
        public ActionResult Create()
        {
            return View();
        }

        // POST: /rosters/create
        [HttpPost]
        [Authorize(Roles = "User,Administrator,Developer")]
        public ActionResult Create(Roster roster,  String DriverName, String TeamName, String MotorName)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var motor = _context.Motors.Where(x => x.Name == MotorName).ToList();
                    if (motor != null){
                        roster.Motor = (Motor)motor[0];
                        roster.MotorId = ((Motor)motor[0]).MotorId;
                        roster.Price += ((Motor)motor[0]).Price;
                        roster.Points += ((Motor)motor[0]).Points;
                    }
                    var team = _context.Teams.Where(x => x.Name == TeamName).ToList();
                    if (motor != null)
                    {
                        roster.Team = (Team)team[0];
                        roster.TeamId = ((Team)team[0]).TeamId;
                        roster.Price += ((Team)team[0]).Price;
                        roster.Points += ((Team)team[0]).Points;

                    }
                    var driver = _context.Drivers.Where(x => x.Name == DriverName).ToList();
                    if (motor != null)
                    {
                        roster.Driver = (Driver)driver[0];
                        roster.DriverId = ((Driver)driver[0]).DriverId;
                        roster.Price += ((Driver)driver[0]).Price;
                        roster.Points += ((Driver)driver[0]).Points;
                    }
                    if (((Driver)driver[0]).Number >= 10)
                    {
                        roster.UniqueCode = ((Driver)driver[0]).Number.ToString() + TeamName + MotorName;
                    }
                    else
                    {
                        roster.UniqueCode = '0' + ((Driver)driver[0]).Number.ToString() + TeamName + MotorName;
                    }

                    roster.User = this.User.Identity.Name;

                    _context.Rosters.Add(roster);

                    _context.SaveChanges();

                    return RedirectToAction("Index", "Rosters");
                }
                else
                {
                    var errors = ModelState.Select(x => x.Value.Errors)
                           .Where(y => y.Count > 0)
                           .ToList();
                }
            }
            catch (Exception e)
            {
                return Json(new { error = e.Message }, JsonRequestBehavior.AllowGet);
            }
            return View(roster);
        }

        // GET: /rosters/edit/{id}
        [HttpGet]
        [Authorize(Roles = "Administrator")]
        public ActionResult Edit(int id)
        {
            var motor = _context.Motors.Find(id);

            if (motor == null)
            {
                return HttpNotFound();
            }

            return View(motor);
        }

        // POST: /rosters/edit
        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public ActionResult Edit(Roster roster)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var oldRoster = _context.Rosters.Find(roster.MotorId);

                    if (oldRoster == null)
                    {
                        return HttpNotFound();
                    }

                    oldRoster.Points = roster.Points;
                    oldRoster.Price = roster.Price;
                    oldRoster.Motor = roster.Motor;
                    oldRoster.MotorId = roster.MotorId;
                    oldRoster.Team = roster.Team;
                    oldRoster.TeamId = roster.TeamId;
                    oldRoster.Driver = roster.Driver;
                    oldRoster.DriverId = roster.DriverId;

                    TryUpdateModel(oldRoster);

                    _context.SaveChanges();

                    return RedirectToAction("Index", "Rosters");
                }
            }
            catch (Exception e)
            {
                return Json(new { error_message = e.Message }, JsonRequestBehavior.AllowGet);
            }

            return View(roster);
        }

        // GET: /rosters/update
        [HttpGet]
        [Authorize(Roles = "Administrator")]
        public ActionResult Update(Roster roster)
        {
            try
            {
                var rosters = _context.Rosters.ToList();

                foreach (Roster current in rosters)
                {
                    current.Points = current.Driver.Points + current.Motor.Points + current.Team.Points;
                    TryUpdateModel(current);
                }

                _context.SaveChanges();

                return RedirectToAction("Index", "Rosters");
                
            }
            catch (Exception e)
            {
                return Json(new { error_message = e.Message }, JsonRequestBehavior.AllowGet);
            }

            return View(roster);
        }

        // GET: /rosters/delete/{id}
        [HttpGet]
        [Authorize(Roles = "Administrator")]
        public ActionResult Delete(int id)
        {
            var roster = _context.Rosters.Find(id);

            if (roster == null)
            {
                return HttpNotFound();
            }

            _context.Rosters.Remove(roster);

            _context.SaveChanges();

            return RedirectToAction("Index", "Rosters");
        }
    }
}
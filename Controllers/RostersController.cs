using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using fantasyF1.Models;

namespace fantasyF1.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class RostersController : Controller
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();
        // GET: /rosters/index
        [HttpGet]

        [AllowAnonymous]
        public ActionResult Index()
        {
            var rosters = _context.Rosters.OrderBy(x => x.Points).ToList();

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
        public ActionResult Create(Roster roster, String DriverName, String TeamName, String MotorName)
        {
            Console.WriteLine(0);
            try
            {
                if (ModelState.IsValid)
                {
                    var motor = _context.Motors.Where(x => x.Name == MotorName);
                    Console.WriteLine(1);
                    if (motor != null){
                        roster.Motor = (Motor)motor;
                        roster.MotorId = ((Motor)motor).MotorId;
                        roster.Price += ((Motor)motor).Price;
                    }
                    var team = _context.Teams.Where(x => x.Name == TeamName);
                    Console.WriteLine(2);
                    if (motor != null)
                    {
                        roster.Team = (Team)team;
                        roster.TeamId = ((Team)team).TeamId;
                        roster.Price += ((Team)team).Price;

                    }
                    var driver = _context.Drivers.Where(x => x.Name == DriverName);
                    Console.WriteLine(3);
                    if (motor != null)
                    {
                        roster.Driver = (Driver)driver;
                        roster.DriverId = ((Driver)driver).DriverId;
                        roster.Price += ((Driver)driver).Price;
                    }
                    Console.WriteLine(4);
                    if (((Driver)driver).Number >= 10)
                    {
                        roster.UniqueCode = ((Driver)driver).Number.ToString() + TeamName + MotorName;
                    }
                    else
                    {
                        roster.UniqueCode = '0' + ((Driver)driver).Number.ToString() + TeamName + MotorName;
                    }
                    Console.WriteLine(5);

                    _context.Rosters.Add(roster);

                    _context.SaveChanges();

                    return RedirectToAction("Index", "Rosters");
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

        // GET: /rosters/delete/{id}
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var motor = _context.Rosters.Find(id);

            if (motor == null)
            {
                return HttpNotFound();
            }

            _context.Rosters.Remove(motor);

            _context.SaveChanges();

            return RedirectToAction("Index", "Rosters");
        }
    }
}
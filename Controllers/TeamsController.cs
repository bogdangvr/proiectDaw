using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using fantasyF1.Models;

namespace fantasyF1.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class TeamsController : Controller
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();
        // GET: /teams/index
        [HttpGet]
        [AllowAnonymous]
        public ActionResult Index()
        {
            var team = _context.Teams.OrderBy(x => x.ExpectedFinish).ToList();

            ViewBag.Teams = team;

            return View();
        }

        // GET: /teams/create
        [HttpGet]
        [AllowAnonymous]
        public ActionResult Create()
        {
            return View();
        }

        // POST: /teams/create
        [HttpPost]
        public ActionResult Create(Team team)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Teams.Add(team);

                    _context.SaveChanges();

                    return RedirectToAction("Index", "Teams");
                }
            }
            catch (Exception e)
            {
                return Json(new { error = e.Message }, JsonRequestBehavior.AllowGet);
            }
            return View(team);
        }

        // GET: /team/edit/{id}
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var team = _context.Teams.Find(id);

            if (team == null)
            {
                return HttpNotFound();
            }

            return View(team);
        }

        // POST: /team/edit
        [HttpPost]
        public ActionResult Edit(Team team)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var oldTeam = _context.Teams.Find(team.TeamId);

                    if (oldTeam == null)
                    {
                        return HttpNotFound();
                    }

                    oldTeam.Name = team.Name;
                    oldTeam.Points = team.Points;
                    oldTeam.Price = team.Price;
                    oldTeam.ExpectedFinish = team.ExpectedFinish;

                    TryUpdateModel(oldTeam);

                    _context.SaveChanges();

                    return RedirectToAction("Index", "Teams");
                }
            }
            catch (Exception e)
            {
                return Json(new { error_message = e.Message }, JsonRequestBehavior.AllowGet);
            }

            return View(team);
        }

        // GET: /teams/delete/{id}
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var team = _context.Teams.Find(id);

            if (team == null)
            {
                return HttpNotFound();
            }

            _context.Teams.Remove(team);

            _context.SaveChanges();

            return RedirectToAction("Index", "Teams");
        }
    }
}
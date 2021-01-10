using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using fantasyF1.Models;

namespace fantasyF1.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class MotorsController : Controller
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();
        // GET: /motors/index
        [HttpGet]

        [AllowAnonymous]
        public ActionResult Index()
        {
            var motor = _context.Motors.OrderBy(x => x.ExpectedFinish).ToList();

            ViewBag.Motors = motor;

            return View();
        }

        // GET: /motors/create
        [HttpGet]

        [AllowAnonymous]
        public ActionResult Create()
        {
            return View();
        }

        // POST: /motors/create
        [HttpPost]
        public ActionResult Create(Motor motor)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Motors.Add(motor);

                    _context.SaveChanges();

                    return RedirectToAction("Index", "Motors");
                }
            }
            catch (Exception e)
            {
                return Json(new { error = e.Message }, JsonRequestBehavior.AllowGet);
            }
            return View(motor);
        }

        // GET: /motors/edit/{id}
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

        // POST: /motors/edit
        [HttpPost]
        public ActionResult Edit(Motor motor)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var oldMotor = _context.Teams.Find(motor.MotorId);

                    if (oldMotor == null)
                    {
                        return HttpNotFound();
                    }

                    oldMotor.Name = motor.Name;
                    oldMotor.Points = motor.Points;
                    oldMotor.Price = motor.Price;
                    oldMotor.ExpectedFinish = motor.ExpectedFinish;

                    TryUpdateModel(oldMotor);

                    _context.SaveChanges();

                    return RedirectToAction("Index", "Motors");
                }
            }
            catch (Exception e)
            {
                return Json(new { error_message = e.Message }, JsonRequestBehavior.AllowGet);
            }

            return View(motor);
        }

        // GET: /motors/delete/{id}
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var motor = _context.Motors.Find(id);

            if (motor == null)
            {
                return HttpNotFound();
            }

            _context.Motors.Remove(motor);

            _context.SaveChanges();

            return RedirectToAction("Index", "Motors");
        }
    }
}
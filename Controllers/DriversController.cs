using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using fantasyF1.Models;

namespace fantasyF1.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class DriversController : Controller
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();
        // GET: drivers/index
        [HttpGet]
        [AllowAnonymous]
        public ActionResult Index()
        {
            var drivers = _context.Drivers.OrderByDescending(x => x.Points).ThenBy(x => x.ExpectedFinish).ToList();

            ViewBag.Drivers = drivers;

            return View();
        }

        // GET: /drivers/details/{id}
        [HttpGet]
        [AllowAnonymous]
        public ActionResult Details(int id)
        {
            var driver = _context.Drivers.Find(id);

            if (driver == null)
            {
                return HttpNotFound();
            }

            return View(driver);
        }

        // GET: /drivers/create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: /drivers/create
        [HttpPost]
        public ActionResult Create(Driver driver)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Drivers.Add(driver);

                    _context.SaveChanges();

                    return RedirectToAction("Index", "Drivers");
                }
            }
            catch (Exception e)
            {
                return Json(new { error = e.Message }, JsonRequestBehavior.AllowGet);
            }
            return View(driver);
        }

        // GET: /drivers/edit/{id}
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var driver = _context.Drivers.Find(id);

            if (driver == null)
            {
                return HttpNotFound();
            }

            return View(driver);
        }

        // POST: /drivers/edit
        [HttpPost]
        public ActionResult Edit(Driver driver)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var oldDriver = _context.Drivers.Find(driver.DriverId);

                    if (oldDriver == null)
                    {
                        return HttpNotFound();
                    }

                    oldDriver.Name = driver.Name;
                    oldDriver.Number = driver.Number;
                    oldDriver.Price = driver.Price;
                    oldDriver.Nationality = driver.Nationality;
                    oldDriver.ExpectedFinish = driver.ExpectedFinish;
                    oldDriver.Points = driver.Points;

                    TryUpdateModel(oldDriver);

                    _context.SaveChanges();

                    return RedirectToAction("Index", "Drivers");
                }
            }
            catch (Exception e)
            {
                return Json(new { error_message = e.Message }, JsonRequestBehavior.AllowGet);
            }

            return View(driver);
        }

        // GET: /drivers/delete/{id}
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var driver = _context.Drivers.Find(id);

            if (driver == null)
            {
                return HttpNotFound();
            }

            _context.Drivers.Remove(driver);

            _context.SaveChanges();

            return RedirectToAction("Index", "Drivers");
        }
    }
}
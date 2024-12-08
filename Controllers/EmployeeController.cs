using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EmployeeDetailsApp.Models;

namespace EmployeeDetailsApp.Controllers
{
    public class EmployeeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();


        // GET: Teachers
        [HttpGet]
        public ActionResult Index()
        {
            var empList = db.Teachers.ToList();
            return View(empList);
        }

        //get for add teachers
        [HttpGet]
        public ActionResult AddTeachers()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddTeachers(Teacher objData)
        {
            if (ModelState.IsValid)
            {
                using(var db = new ApplicationDbContext())
                {
                    db.Teachers.Add(objData);
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            return View(objData);
        }

        [HttpGet]
        public ActionResult EditTeachers(int? id)
        {
            var db = new ApplicationDbContext();
            var data = db.Teachers.Find(id);
            db.Entry(data).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return View(data);
        }

        [HttpPost]
        public ActionResult EditTeachers(Teacher data)
        {
            if (ModelState.IsValid)
            {
                using (var db = new ApplicationDbContext())
                {
                    var checkData = db.Teachers.Find(data.EmpId);
                    if (checkData != null)
                    {
                        db.Entry(data).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                    return RedirectToAction("index");
                }
            }
            return View();
        }
    }
}
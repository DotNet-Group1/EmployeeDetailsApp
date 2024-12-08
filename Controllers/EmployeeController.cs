using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
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
                    var existingTeacher = db.Teachers.Find(data.EmpId); // Fetch the existing entity
                    if (existingTeacher != null)
                    {
                        existingTeacher.Name = data.Name;
                        existingTeacher.Age = data.Age;
                        existingTeacher.EmailId = data.EmailId;
                        existingTeacher.JoiningDate = data.JoiningDate;

                        db.SaveChanges(); // Save changes
                        return RedirectToAction("Index");
                    }
                }
            }
            return View();
        }
    
        [HttpGet]
        public ActionResult GetTeachers(int? id)
        {
            using(var db = new ApplicationDbContext())
            {
                var data = db.Teachers.Find(id);
                if (data == null)
                {
                    return HttpNotFound();
                }
                return View(data);
            }            
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest); // Return HTTP 400 if id is not provided
            }

            using (var db = new ApplicationDbContext())
            {
                var teacher = db.Teachers.Find(id);
                if (teacher == null)
                {
                    return HttpNotFound(); // Return HTTP 404 if the teacher is not found
                }
                return View(teacher); // Pass the teacher to the confirmation view
            }
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken] 
        public ActionResult DeleteConfirmed(int id)
        {
            using (var db = new ApplicationDbContext())
            {
                var teacher = db.Teachers.Find(id);
                if (teacher != null)
                {
                    db.Teachers.Remove(teacher); 
                    db.SaveChanges(); 
                }
            }
            return RedirectToAction("Index");
        }

    }
}
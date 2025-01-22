using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
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


        // GET: tblTeachers
        [HttpGet]
        public ActionResult Index()
        {
            var empList = db.tblTeachers.ToList();
            return View(empList);
        }

        //get for add teachers
        [HttpGet]
        public ActionResult AddtblTeachers()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddtblTeachers(Teacher objData, HttpPostedFileBase profileImage, HttpPostedFileBase resume)
        {
            if (ModelState.IsValid)
            {
                //if (profileImage != null)
                //{
                //    string profileImagePath = Path.Combine(Server.MapPath("~/Uploads/Images"), profileImage.FileName);
                //    profileImage.SaveAs(profileImagePath);
                //    objData.profileImage = "/Uploads/Images/" + profileImage.FileName;
                //}

                //if (resume != null)
                //{
                //    string resumePath = Path.Combine(Server.MapPath("~/Uploads/Files"), resume.FileName);
                //    resume.SaveAs(resumePath);
                //    objData.resume = "/Uploads/Files/" + resume.FileName;
                //}

                if (profileImage != null && profileImage.ContentLength > 0)
                {
                    string directoryPath = Server.MapPath("~/Uploads/Images");

                    // Create directory if it doesn't exist
                    if (!Directory.Exists(directoryPath))
                    {
                        Directory.CreateDirectory(directoryPath);
                    }

                    // Save the profile image
                    string filePath = Path.Combine(directoryPath, Path.GetFileName(profileImage.FileName));
                    profileImage.SaveAs(filePath);
                    objData.profileImage = "/Uploads/Images/" + Path.GetFileName(profileImage.FileName);
                }

                if (resume != null && resume.ContentLength > 0)
                {
                    string directoryPath = Server.MapPath("~/Uploads/Resumes");

                    // Create directory if it doesn't exist
                    if (!Directory.Exists(directoryPath))
                    {
                        Directory.CreateDirectory(directoryPath);
                    }

                    // Save the resume
                    string filePath = Path.Combine(directoryPath, Path.GetFileName(resume.FileName));
                    resume.SaveAs(filePath);
                    objData.resume = "/Uploads/Resumes/" + Path.GetFileName(resume.FileName);
                }
                db.tblTeachers.Add(objData);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(objData);
        }

        [HttpGet]
        public ActionResult EdittblTeachers(int? id)
        {
            var db = new ApplicationDbContext();
            var data = db.tblTeachers.Find(id);
            //db.Entry(data).State = System.Data.Entity.EntityState.Modified;
            //db.SaveChanges();
            return View(data);
        }
              
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EdittblTeachers(Teacher teacher, HttpPostedFileBase profileImage, HttpPostedFileBase resume)
        {
            if (ModelState.IsValid)
            {
                using (var db = new ApplicationDbContext())
                {
                    var existingTeacher = db.tblTeachers.Find(teacher.EmpId);
                    if (existingTeacher != null)
                    {
                        if (profileImage != null && profileImage.ContentLength > 0)
                        {
                            string directoryPath = Server.MapPath("~/Uploads/Images");

                            // Create directory if it doesn't exist
                            if (!Directory.Exists(directoryPath))
                            {
                                Directory.CreateDirectory(directoryPath);
                            }

                            // Save the profile image
                            string filePath = Path.Combine(directoryPath, Path.GetFileName(profileImage.FileName));
                            profileImage.SaveAs(filePath);
                            teacher.profileImage = "/Uploads/Images/" + Path.GetFileName(profileImage.FileName);
                        }

                        if (resume != null && resume.ContentLength > 0)
                        {
                            string directoryPath = Server.MapPath("~/Uploads/Resumes");

                            // Create directory if it doesn't exist
                            if (!Directory.Exists(directoryPath))
                            {
                                Directory.CreateDirectory(directoryPath);
                            }

                            // Save the resume
                            string filePath = Path.Combine(directoryPath, Path.GetFileName(resume.FileName));
                            resume.SaveAs(filePath);
                            teacher.resume = "/Uploads/Resumes/" + Path.GetFileName(resume.FileName);
                        }

                        if (existingTeacher != null)
                        {
                            existingTeacher.Name = teacher.Name;
                            existingTeacher.Age = teacher.Age;
                            existingTeacher.EmailId = teacher.EmailId;
                            existingTeacher.JoiningDate = teacher.JoiningDate;
                            existingTeacher.profileImage = teacher.profileImage;
                            existingTeacher.resume = teacher.resume;
                            db.SaveChanges(); // Save changes
                            return RedirectToAction("Index");
                        }
                    }
                }

                //db.Entry(teacher).State = EntityState.Modified;
                //db.SaveChanges();
                //return RedirectToAction("Index"); // Return to Index after successful save
            }

            // If ModelState is invalid, return the same view with the teacher data
            return View(teacher);
        }

        [HttpGet]
        public ActionResult GettblTeachers(int? id)
        {
            using(var db = new ApplicationDbContext())
            {
                var data = db.tblTeachers.Find(id);
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
                var teacher = db.tblTeachers.Find(id);
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
                var teacher = db.tblTeachers.Find(id);
                if (teacher != null)
                {
                    db.tblTeachers.Remove(teacher); 
                    db.SaveChanges(); 
                }
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult GetAlltblTeachers()
        {
            var empList = db.tblTeachers.ToList();
            return View(empList);
        }

    }
}
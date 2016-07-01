using AucklandSchool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AucklandSchool.Controllers
{
    public class SubjectController : Controller
    {
        // GET: Subject List
        public ActionResult Index()
        {
            using (var db = new AucklandSchoolEntities())
            {
                var list = (from s in db.Subjects
                            join sts in db.Subject_Teacher_Student on s.Id equals sts.SubjectId
                                into first
                            from f in first.DefaultIfEmpty()
                            select new
                            {
                                s.Id,
                                s.Name,
                                TeracherFullName = f.Teacher.FirstName + " " + f.Teacher.LastName,
                                f.Student
                            }).GroupBy(f => new { f.Id, f.Name, f.TeracherFullName }, (key, group) => new SubjectVM
                            {
                                Id = key.Id,
                                Name = key.Name,
                                TeacherName = key.TeracherFullName,
                                StudentCount = group.Where(f => f.Student != null).Distinct().Count()
                            }).ToList();

                return View(list);
            }
        }

        public ActionResult Details(int id)
        {
            using (var db = new AucklandSchoolEntities())
            {
                var subject = (from s in db.Subjects
                               join sts in db.Subject_Teacher_Student on s.Id equals sts.SubjectId
                               into first
                               from f in first.DefaultIfEmpty()
                               where s.Id == id
                               select new
                               {
                                   s.Name,
                                   f
                               }).GroupBy(p => new { p.Name }, (key, group) => new SubjectDetailVM
                               {
                                   SubjectName = key.Name,
                                   Teacher = group.Select(f => f.f.Teacher).FirstOrDefault(),
                                   StudentList = group.Where(f => f.f.Student != null).Select(f => f.f.Student).Distinct().ToList()
                               }).FirstOrDefault();
                return View(subject);
            }
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            if (id == 0)
            {
                SubjectEditVM subject = new SubjectEditVM();
                subject.Id = 0;
                ViewBag.Label = "Create";
                return View(subject);
            }
            else
            {
                using (var db = new AucklandSchoolEntities())
                {
                    var subject = db.Subjects.Where(f => f.Id == id).Select(f => new SubjectEditVM
                    {
                        Id = f.Id,
                        Name = f.Name
                    }).FirstOrDefault();
                    ViewBag.Label = "Edit";
                    return View(subject);
                }
            }

        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SubjectEditVM VM)
        {
            if (ModelState.IsValid)
            {
                if (VM.Id == 0)
                {
                    using (var db = new AucklandSchoolEntities())
                    {
                        Subject subject = new Subject();
                        subject.Name = VM.Name;
                        db.Subjects.Add(subject);
                        db.SaveChanges();
                    }
                }
                else
                {
                    using (var db = new AucklandSchoolEntities())
                    {
                        var subject = db.Subjects.Where(f => f.Id == VM.Id).FirstOrDefault();
                        subject.Name = VM.Name;
                        db.SaveChanges();
                    }
                }
                return RedirectToAction("Index", "Subject");
            }
            else
            {
                ViewBag.Label = VM.Id == 0 ? "Create" : "Edit";
                return View(VM);
            }

        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            using (var db = new AucklandSchoolEntities())
            {
                var listOfSTS = db.Subject_Teacher_Student.Where(f => f.SubjectId == id).ToList();
                foreach (var item in listOfSTS)
                {
                    db.Subject_Teacher_Student.Remove(item);
                }

                var subject = db.Subjects.Where(f => f.Id == id).FirstOrDefault();
                db.Subjects.Remove(subject);
                db.SaveChanges();
                return RedirectToAction("Index", "Subject");
            }
        }
    }
}
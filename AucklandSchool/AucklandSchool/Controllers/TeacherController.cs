using AucklandSchool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AucklandSchool.Controllers
{
    public class TeacherController : Controller
    {
        // GET: Teacher
        public ActionResult Index()
        {
            using (var db = new AucklandSchoolEntities())
            {
                var list = (from t in db.Teachers
                            join sts in db.Subject_Teacher_Student on t.Id equals sts.TeacherId
                                into first
                            from f in first.DefaultIfEmpty()
                            select new
                            {
                                t.Id,
                                TeracherFullName = t.FirstName + " " + t.LastName,
                                f.Subject
                            }).GroupBy(f => new { f.Id, f.TeracherFullName }, (key, group) => new TeacherVM
                            {
                                Id = key.Id,
                                Name = key.TeracherFullName,
                                SubjectCount = group.Where(f => f.Subject != null).Distinct().Count()
                            }).ToList();

                return View(list);
            }
        }

        public ActionResult Details(int id)
        {
            using (var db = new AucklandSchoolEntities())
            {
                var teacher = (from t in db.Teachers
                               join sts in db.Subject_Teacher_Student on t.Id equals sts.TeacherId
                                   into first
                               from f in first.DefaultIfEmpty()
                               where t.Id == id
                               select new
                               {
                                   t.FirstName,
                                   t.LastName,
                                   t.Gender,
                                   f.Subject
                               }).GroupBy(p => new { p.Gender, p.FirstName, p.LastName }, (key, group) => new TeacherDetailVM
                               {
                                   TeacherFirstName = key.FirstName,
                                   TeacherLastName = key.LastName,
                                   TeacherGender = key.Gender,
                                   SubjectList = group.Select(f => f.Subject).Distinct().ToList()
                               }).FirstOrDefault();

                return View(teacher);
            }
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            if (id == 0)
            {
                TeacherEditVM teacher = new TeacherEditVM();
                teacher.Id = 0;
                ViewBag.Label = "Create";
                return View(teacher);
            }
            else
            {
                using (var db = new AucklandSchoolEntities())
                {
                    var teacher = db.Teachers.Where(f => f.Id == id).Select(f => new TeacherEditVM
                    {
                        Id = f.Id,
                        FirstName = f.FirstName,
                        LastName = f.LastName,
                        Gender = f.Gender
                    }).FirstOrDefault();
                    ViewBag.Label = "Edit";
                    return View(teacher);
                }
            }

        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TeacherEditVM VM)
        {
            if (ModelState.IsValid)
            {
                if (VM.Id == 0)
                {
                    using (var db = new AucklandSchoolEntities())
                    {
                        Teacher teacher = new Teacher();
                        teacher.FirstName = VM.FirstName;
                        teacher.LastName = VM.LastName;
                        teacher.Gender = VM.Gender;
                        db.Teachers.Add(teacher);
                        db.SaveChanges();
                    }
                }
                else
                {
                    using (var db = new AucklandSchoolEntities())
                    {
                        var teacher = db.Teachers.Where(f => f.Id == VM.Id).FirstOrDefault();
                        teacher.FirstName = VM.FirstName;
                        teacher.LastName = VM.LastName;
                        teacher.Gender = VM.Gender;
                        db.SaveChanges();
                    }
                }
                return RedirectToAction("Index", "Teacher");
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
                var listOfSTS = db.Subject_Teacher_Student.Where(f => f.TeacherId == id).ToList();
                foreach (var item in listOfSTS)
                {
                    db.Subject_Teacher_Student.Remove(item);
                }

                var teacher = db.Teachers.Where(f => f.Id == id).FirstOrDefault();
                db.Teachers.Remove(teacher);
                db.SaveChanges();
                return RedirectToAction("Index", "Teacher");
            }
        }
    }
}
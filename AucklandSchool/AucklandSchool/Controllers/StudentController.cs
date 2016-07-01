using AucklandSchool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AucklandSchool.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            using (var db = new AucklandSchoolEntities())
            {
                var list = (from s in db.Students
                            join sts in db.Subject_Teacher_Student on s.Id equals sts.StudentId
                                into first
                            from f in first.DefaultIfEmpty()
                            select new
                            {
                                s.Id,
                                StudentFullName = s.FirstName + " " + s.LastName,
                                f.Subject
                            }).GroupBy(f => new { f.Id, f.StudentFullName }, (key, group) => new StudentVM
                            {
                                Id = key.Id,
                                Name = key.StudentFullName,
                                SubjectCount = group.Where(f => f.Subject != null).Distinct().Count()
                            }).ToList();

                return View(list);
            }
        }

        public ActionResult Details(int id)
        {
            using (var db = new AucklandSchoolEntities())
            {
                var list = (from st in db.Students
                            join sts in db.Subject_Teacher_Student.DefaultIfEmpty() on st.Id equals sts.StudentId into firstJoin
                            from sts in firstJoin.DefaultIfEmpty()
                            join s in db.Subjects on sts.SubjectId equals s.Id into secondJoin
                            from s in secondJoin.DefaultIfEmpty()
                            where st.Id == id
                            select new
                            {
                                st.FirstName,
                                st.LastName,
                                st.Gender,
                                s
                            }).GroupBy(p => new { p.FirstName, p.LastName, p.Gender }, (key, group) => new StudentDetailVM
                            {
                                StudentFirstName = key.FirstName,
                                StudentLastName = key.LastName,
                                StudentGender = key.Gender,
                                SubjectList = group.Select(x => x.s).ToList()
                            }).FirstOrDefault();
                return View(list);
            }
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            if (id == 0)
            {
                StudentEditVM student = new StudentEditVM();
                student.Id = 0;
                ViewBag.Label = "Create";
                return View(student);
            }
            else
            {
                using (var db = new AucklandSchoolEntities())
                {
                    var student = db.Students.Where(f => f.Id == id).Select(f => new StudentEditVM
                    {
                        Id = f.Id,
                        FirstName = f.FirstName,
                        LastName = f.LastName,
                        Gender = f.Gender
                    }).FirstOrDefault();
                    ViewBag.Label = "Edit";
                    return View(student);
                }
            }

        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(StudentEditVM VM)
        {
            if (ModelState.IsValid)
            {
                if (VM.Id == 0)
                {
                    using (var db = new AucklandSchoolEntities())
                    {
                        Student student = new Student();
                        student.FirstName = VM.FirstName;
                        student.LastName = VM.LastName;
                        student.Gender = VM.Gender;
                        db.Students.Add(student);
                        db.SaveChanges();
                    }
                }
                else
                {
                    using (var db = new AucklandSchoolEntities())
                    {
                        var student = db.Students.Where(f => f.Id == VM.Id).FirstOrDefault();
                        student.FirstName = VM.FirstName;
                        student.LastName = VM.LastName;
                        student.Gender = VM.Gender;
                        db.SaveChanges();
                    }
                }
                return RedirectToAction("Index", "Student");
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
                var listOfSTS = db.Subject_Teacher_Student.Where(f => f.StudentId == id).ToList();
                foreach (var item in listOfSTS)
                {
                    db.Subject_Teacher_Student.Remove(item);
                }

                var student = db.Students.Where(f => f.Id == id).FirstOrDefault();
                db.Students.Remove(student);
                db.SaveChanges();
                return RedirectToAction("Index", "Student");
            }
        }
    }
}
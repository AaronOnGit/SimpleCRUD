using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AucklandSchool.Models
{
    public class SubjectVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string TeacherName { get; set; }
        public int StudentCount { get; set; }
    }

    public class SubjectDetailVM
    {
        public string SubjectName { get; set; }

        //public List<Teacher> TeacherList { get; set; }

        public Teacher Teacher { get; set; }
        //public int TeacherId { get; set; }

        //public string TeacherFirstName { get; set; }

        //public string TeacherLastName { get; set; }

        public List<Student> StudentList { get; set; }
    }

    public class SubjectEditVM
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Subject Name is required")]
        [Display(Name = "Subject Name")]
        public string Name { get; set; }
    }

    public class TeacherVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int SubjectCount { get; set; }
    }

    public class TeacherDetailVM
    {
        public string TeacherFirstName { get; set; }

        public string TeacherLastName { get; set; }

        public string TeacherGender { get; set; }

        public List<Subject> SubjectList { get; set; }
    }

    public class TeacherEditVM
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "First name is required")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last name is required")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Gender is required")]
        [Display(Name = "Gender")]
        public string Gender { get; set; }
    }

    public class StudentVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int SubjectCount { get; set; }
    }

    public class StudentDetailVM
    {
        public string StudentFirstName { get; set; }

        public string StudentLastName { get; set; }

        public string StudentGender { get; set; }

        public List<Subject> SubjectList { get; set; }
    }

    public class StudentEditVM
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "First name is required")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last name is required")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Gender is required")]
        [Display(Name = "Gender")]
        public string Gender { get; set; }
    }
}

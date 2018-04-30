using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ContosoUniversity.Models;

namespace ContosoUniversity.DAL
{
    public class SchoolInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<SchoolContext>
    {
        protected override void Seed(SchoolContext context)
        {
            var students = new List<Student>
            {
                new Student{FirstMidName="Carson",LastName="Alexander",EnrollmentDate=DateTime.Parse("2005-09-01")},
                new Student{FirstMidName="Meredith",LastName="Alonso",EnrollmentDate=DateTime.Parse("2002-09-01")},
                new Student{FirstMidName="Arturo",LastName="Anand",EnrollmentDate=DateTime.Parse("2003-09-01")},
                new Student{FirstMidName="Gytis",LastName="Barzdukas",EnrollmentDate=DateTime.Parse("2002-09-01")},
                new Student{FirstMidName="Yan",LastName="Li",EnrollmentDate=DateTime.Parse("2002-09-01")},
                new Student{FirstMidName="Peggy",LastName="Justice",EnrollmentDate=DateTime.Parse("2001-09-01")},
                new Student{FirstMidName="Laura",LastName="Norman",EnrollmentDate=DateTime.Parse("2003-09-01")},
                new Student{FirstMidName="Nino",LastName="Olivetto",EnrollmentDate=DateTime.Parse("2005-09-01")}
            };

            students.ForEach(s => context.Students.Add(s));
            context.SaveChanges();

            var courses = new List<Course>
            {
                new Course{CoursesID=1050, Titles="Chemistry", Credits=3},
                new Course{CoursesID=4022,Titles="Microeconomics",Credits=3},
                new Course{CoursesID=4041,Titles="Macroeconomics",Credits=3},
                new Course{CoursesID=1045,Titles="Calculus",Credits=4},
                new Course{CoursesID=3141,Titles="Trigonometry",Credits=4},
                new Course{CoursesID=2021,Titles="Composition",Credits=3},
                new Course{CoursesID=2042,Titles="Literature",Credits=4}
            };

            courses.ForEach(s => context.Courses.Add(s));
            context.SaveChanges();

            var enrollments = new List<Enrollment>
            {
                new Enrollment{StudentID=1,CoursesID=1,Grade=Grade.A},
                new Enrollment{StudentID=1,CoursesID=2,Grade=Grade.C},
                new Enrollment{StudentID=1,CoursesID=3,Grade=Grade.B},
                new Enrollment{StudentID=2,CoursesID=4,Grade=Grade.B},
                new Enrollment{StudentID=2,CoursesID=5,Grade=Grade.F},
                new Enrollment{StudentID=2,CoursesID=6,Grade=Grade.F},
                new Enrollment{StudentID=3,CoursesID=1},
                new Enrollment{StudentID=4,CoursesID=1},
                new Enrollment{StudentID=4,CoursesID=2,Grade=Grade.F},
                new Enrollment{StudentID=5,CoursesID=3,Grade=Grade.C},
                new Enrollment{StudentID=6,CoursesID=4},
                new Enrollment{StudentID=7,CoursesID=5,Grade=Grade.A},
            };
            enrollments.ForEach(e => context.Enrollments.Add(e));
            context.SaveChanges();
        }
    }
}
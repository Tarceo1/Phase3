using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using LMS.Models.LMSModels; // Added when 'protected TeamXLMSContext db' was uncommented
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;

namespace LMS.Controllers
{
    public class CommonController : Controller
    {

        /*******Begin code to modify********/

        // TODO: Uncomment and change 'X' after you have scaffoled


        protected Team94LMSContext db;

        public CommonController()
        {
            db = new Team94LMSContext();
        }


        /*
         * WARNING: This is the quick and easy way to make the controller
         *          use a different LibraryContext - good enough for our purposes.
         *          The "right" way is through Dependency Injection via the constructor 
         *          (look this up if interested).
        */

        // TODO: Uncomment and change 'X' after you have scaffoled

        public void UseLMSContext(Team94LMSContext ctx)
        {
            db = ctx;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }




        /// <summary>
        /// Retreive a JSON array of all departments from the database.
        /// Each object in the array should have a field called "name" and "subject",
        /// where "name" is the department name and "subject" is the subject abbreviation.
        /// </summary>
        /// <returns>The JSON array</returns>
        public IActionResult GetDepartments()
        {

            using (Team94LMSContext db = new Team94LMSContext())
            {
                var result = from p in db.Departments
                             select new { name = p.Name, subject = p.Abbr };

                return Json(result.ToArray());
            }
        }



        /// <summary>
        /// Returns a JSON array representing the course catalog.
        /// Each object in the array should have the following fields:
        /// "subject": The subject abbreviation, (e.g. "CS")
        /// "dname": The department name, as in "Computer Science"
        /// "courses": An array of JSON objects representing the courses in the department.
        ///            Each field in this inner-array should have the following fields:
        ///            "number": The course number (e.g. 5530)
        ///            "cname": The course name (e.g. "Database Systems")
        /// </summary>
        /// <returns>The JSON array</returns>
        public IActionResult GetCatalog()
        {
            using (db)
            {
                var result =
                    from d in db.Departments
                    select new
                    {
                        subject = d.Abbr,
                        dname = d.Name,
                        courses =
                    db.Courses.Where(x => x.Department == d.Abbr).
                    Select(x => new { number = x.Number, cname = x.Name }).ToArray()
                    };

                return Json(result.ToArray());
            }
        }

        /// <summary>
        /// Returns a JSON array of all class offerings of a specific course.
        /// Each object in the array should have the following fields:
        /// "season": the season part of the semester, such as "Fall"
        /// "year": the year part of the semester
        /// "location": the location of the class
        /// "start": the start time in format "hh:mm:ss"
        /// "end": the end time in format "hh:mm:ss"
        /// "fname": the first name of the professor
        /// "lname": the last name of the professor
        /// </summary>
        /// <param name="subject">The subject abbreviation, as in "CS"</param>
        /// <param name="number">The course number, as in 5530</param>
        /// <returns>The JSON array</returns>
        public IActionResult GetClassOfferings(string subject, int number)
        {
            using (db)
            {
                var result =
                    from d in db.Classes
                    join p in db.Professors
                    on d.Prof equals p.UId
                    join c in db.Courses
                    on d.Course equals c.CourseId
                    where c.Department == subject && c.Number == number
                    select new
                    {
                        season = d.Semester,
                        year = d.Year,
                        location = d.Loc,
                        start = d.Start.ToString("hh:mm:ss"),
                        end = d.End.ToString("hh:mm:ss"),
                        fname = p.FirstName,
                        lname = p.LastName
                    };
                return Json(result.ToArray());
            }

        }

        /// <summary>
        /// This method does NOT return JSON. It returns plain text (containing html).
        /// Use "return Content(...)" to return plain text.
        /// Returns the contents of an assignment.
        /// </summary>
        /// <param name="subject">The course subject abbreviation</param>
        /// <param name="num">The course number</param>
        /// <param name="season">The season part of the semester for the class the assignment belongs to</param>
        /// <param name="year">The year part of the semester for the class the assignment belongs to</param>
        /// <param name="category">The name of the assignment category in the class</param>
        /// <param name="asgname">The name of the assignment in the category</param>
        /// <returns>The assignment contents</returns>
        public IActionResult GetAssignmentContents(string subject, int num, string season, int year, string category, string asgname)
        {
            using (db)
            {
                var result =
                    from a in db.Assignments
                    join c in db.AssignmentCatagories
                    on a.Catagory equals c.CataId
                    select new
                    {
                        a,
                        c
                    }
                    into assWithCate
                    join cla in db.Classes
                    on assWithCate.c.Class equals cla.ClassId
                    select new
                    {
                        ass = assWithCate.a,
                        cata = assWithCate.c,
                        cla
                    }
                    into assWithClass
                    join cour in db.Courses
                    on assWithClass.cla.Course equals cour.CourseId
                    where cour.Department == subject &&
                        cour.Number == num &&
                        assWithClass.cla.Semester == season &&
                        assWithClass.cla.Year == year &&
                        assWithClass.cata.Name == category &&
                        assWithClass.ass.Name == asgname
                    select assWithClass.ass.Content;

                string toReturn = result.Single();
                return Content(toReturn);
            }
        }

        /// <summary>
        /// This method does NOT return JSON. It returns plain text (containing html).
        /// Use "return Content(...)" to return plain text.
        /// Returns the contents of an assignment submission.
        /// Returns the empty string ("") if there is no submission.
        /// </summary>
        /// <param name="subject">The course subject abbreviation</param>
        /// <param name="num">The course number</param>
        /// <param name="season">The season part of the semester for the class the assignment belongs to</param>
        /// <param name="year">The year part of the semester for the class the assignment belongs to</param>
        /// <param name="category">The name of the assignment category in the class</param>
        /// <param name="asgname">The name of the assignment in the category</param>
        /// <param name="uid">The uid of the student who submitted it</param>
        /// <returns>The submission text</returns>
        public IActionResult GetSubmissionText(string subject, int num, string season, int year, string category, string asgname, string uid)
        {
            using (db)
            {
                var result =
                    from a in db.Assignments
                    join c in db.AssignmentCatagories
                    on a.Catagory equals c.CataId
                    select new
                    {
                        a,
                        c
                    }
                    into assWithCate
                    join cla in db.Classes
                    on assWithCate.c.Class equals cla.ClassId
                    select new
                    {
                        ass = assWithCate.a,
                        cata = assWithCate.c,
                        cla
                    }
                    into assWithClass
                    join cour in db.Courses
                    on assWithClass.cla.Course equals cour.CourseId
                    where cour.Department == subject &&
                        cour.Number == num &&
                        assWithClass.cla.Semester == season &&
                        assWithClass.cla.Year == year &&
                        assWithClass.cata.Name == category &&
                        assWithClass.ass.Name == asgname
                    join s in db.Submissions
                    on assWithClass.ass.AssignId equals s.Assignment
                    where s.Student == uid
                    select s.Content;
                string toReturn;
                if (result.Count() > 0)
                {
                   toReturn = result.Single();
                } else
                {
                    toReturn = null;
                }
                return Content(toReturn);
            }
        }


        /// <summary>
        /// Gets information about a user as a single JSON object.
        /// The object should have the following fields:
        /// "fname": the user's first name
        /// "lname": the user's last name
        /// "uid": the user's uid
        /// "department": (professors and students only) the name (such as "Computer Science") of the department for the user. 
        ///               If the user is a Professor, this is the department they work in.
        ///               If the user is a Student, this is the department they major in.    
        ///               If the user is an Administrator, this field is not present in the returned JSON
        /// </summary>
        /// <param name="uid">The ID of the user</param>
        /// <returns>
        /// The user JSON object 
        /// or an object containing {success: false} if the user doesn't exist
        /// </returns>
        public IActionResult GetUser(string uid)
        {
            using (db)
            {
                if (db.Students.Select(x => x.UId).Where(x => x == uid).Count() == 1)
                    return GetStudent(uid);

                if (db.Professors.Select(x => x.UId).Where(x => x == uid).Count() == 1)
                    return GetProf(uid);

                if (db.Admins.Select(x => x.UId).Where(x => x == uid).Count() == 1)
                    return getAdmin(uid);
            }
            return Json(new { success = false });
        }

        /// <summary>
        /// Private method used to query the Admin specific database for
        /// user access. For more info, see GetUser
        /// </summary>
        private IActionResult getAdmin(string uid)
        {
            using (db)
            {
                var result =
                    from a in db.Admins
                    where a.UId == uid
                    select new
                    {
                        fname = a.FirstName,
                        lname = a.LastName,
                        uid = a.UId
                    };

                return Json(result.Single());
            }
        }

        /// <summary>
        /// Private method used to query the Professor specific database for
        /// user access. For more info, see GetUser
        /// </summary>
        private IActionResult GetProf(string uid)
        {
            using (db)
            {
                var result =
                    from a in db.Professors
                    where a.UId == uid
                    select new
                    {
                        fname = a.FirstName,
                        lname = a.LastName,
                        uid = a.UId,
                        department = a.Department
                    };

                return Json(result.Single());
            }
        }

        /// <summary>w
        /// Private method used to query the Student specific database for
        /// user access. For more info, see GetUser
        /// </summary>
        private IActionResult GetStudent(string uid)
        {
            using (db)
            {
                var result =
                    from s in db.Students
                    where s.UId == uid
                    select new
                    {
                        fname = s.FirstName,
                        lname = s.LastName,
                        uid = s.UId,
                        department = s.Major
                    };
                var debug = result.Single();
                Debug.WriteLine($"{debug.department} {debug.fname} {debug.lname} {debug.uid}");
                return Json(result.Single());
            }
        }


        /*******End code to modify********/

    }
}
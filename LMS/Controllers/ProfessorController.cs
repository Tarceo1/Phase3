using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LMS.Models.LMSModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LMS.Controllers
{
    [Authorize(Roles = "Professor")]
    public class ProfessorController : CommonController
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Students(string subject, string num, string season, string year)
        {
            ViewData["subject"] = subject;
            ViewData["num"] = num;
            ViewData["season"] = season;
            ViewData["year"] = year;
            return View();
        }

        public IActionResult Class(string subject, string num, string season, string year)
        {
            ViewData["subject"] = subject;
            ViewData["num"] = num;
            ViewData["season"] = season;
            ViewData["year"] = year;
            return View();
        }

        public IActionResult Categories(string subject, string num, string season, string year)
        {
            ViewData["subject"] = subject;
            ViewData["num"] = num;
            ViewData["season"] = season;
            ViewData["year"] = year;
            return View();
        }

        public IActionResult CatAssignments(string subject, string num, string season, string year, string cat)
        {
            ViewData["subject"] = subject;
            ViewData["num"] = num;
            ViewData["season"] = season;
            ViewData["year"] = year;
            ViewData["cat"] = cat;
            return View();
        }

        public IActionResult Assignment(string subject, string num, string season, string year, string cat, string aname)
        {
            ViewData["subject"] = subject;
            ViewData["num"] = num;
            ViewData["season"] = season;
            ViewData["year"] = year;
            ViewData["cat"] = cat;
            ViewData["aname"] = aname;
            return View();
        }

        public IActionResult Submissions(string subject, string num, string season, string year, string cat, string aname)
        {
            ViewData["subject"] = subject;
            ViewData["num"] = num;
            ViewData["season"] = season;
            ViewData["year"] = year;
            ViewData["cat"] = cat;
            ViewData["aname"] = aname;
            return View();
        }

        public IActionResult Grade(string subject, string num, string season, string year, string cat, string aname, string uid)
        {
            ViewData["subject"] = subject;
            ViewData["num"] = num;
            ViewData["season"] = season;
            ViewData["year"] = year;
            ViewData["cat"] = cat;
            ViewData["aname"] = aname;
            ViewData["uid"] = uid;
            return View();
        }

        /*******Begin code to modify********/


        /// <summary>
        /// Returns a JSON array of all the students in a class.
        /// Each object in the array should have the following fields:
        /// "fname" - first name
        /// "lname" - last name
        /// "uid" - user ID
        /// "dob" - date of birth
        /// "grade" - the student's grade in this class
        /// </summary>
        /// <param name="subject">The course subject abbreviation</param>
        /// <param name="num">The course number</param>
        /// <param name="season">The season part of the semester for the class the assignment belongs to</param>
        /// <param name="year">The year part of the semester for the class the assignment belongs to</param>
        /// <returns>The JSON array</returns>
        public IActionResult GetStudentsInClass(string subject, int num, string season, int year)
        {

            using (Team94LMSContext db = new Team94LMSContext())
            {
                var studs =
                    from t1 in db.Courses
                    join t2 in db.Classes
                    on t1.CourseId equals t2.Course
                    join t3 in db.Enrollment
                    on t2.ClassId equals t3.Class
                    join t4 in db.Students
                    on t3.Student equals t4.UId
                    where t1.Department == subject && t1.Number == num && t2.Semester == season && t2.Year == (uint)year
                    select new
                    {
                        fname = t4.FirstName,
                        lname = t4.LastName,
                        uid = t4.UId,
                        dob = t4.Dob,
                        grade = t3.Grade
                    };

                return Json(studs.ToArray());
            }


        }




        /// <summary>
        /// Returns a JSON array with all the assignments in an assignment category for a class.
        /// If the "category" parameter is null, return all assignments in the class.
        /// Each object in the array should have the following fields:
        /// "aname" - The assignment name
        /// "cname" - The assignment category name.
        /// "due" - The due DateTime
        /// "submissions" - The number of submissions to the assignment
        /// </summary>
        /// <param name="subject">The course subject abbreviation</param>
        /// <param name="num">The course number</param>
        /// <param name="season">The season part of the semester for the class the assignment belongs to</param>
        /// <param name="year">The year part of the semester for the class the assignment belongs to</param>
        /// <param name="category">The name of the assignment category in the class, 
        /// or null to return assignments from all categories</param>
        /// <returns>The JSON array</returns>
        public IActionResult GetAssignmentsInCategory(string subject, int num, string season, int year, string category)
        {
            using (Team94LMSContext db = new Team94LMSContext())
            {
                // TODO need to add number of assignments
                // Might need to refactor this

                if(category == null) 
                {
                    var assigns =
                        from t1 in db.Courses
                        join t2 in db.Classes
                        on t1.CourseId equals t2.Course
                        join t3 in db.AssignmentCatagories
                        on t2.ClassId equals t3.Class
                        join t4 in db.Assignments
                        on t3.CataId equals t4.Catagory
                        join t5 in db.Submissions
                        on t4.AssignId equals t5.Assignment
                        where t1.Department == subject && t1.Number == num && t2.Semester == season && t2.Year == (uint)year
                        //group t4 by t5.Student into studGroup
                        select new
                        {
                            aname = t4.Name,
                            cname = t3.Name,
                            due = t4.Due,
                            submissions = 0 //TODO
                        };

                        return Json(assigns.ToArray());

                }
                else
                {
                    var assigns =
                    from t1 in db.Courses
                    join t2 in db.Classes
                    on t1.CourseId equals t2.Course
                    join t3 in db.AssignmentCatagories
                    on t2.ClassId equals t3.Class
                    join t4 in db.Assignments
                    on t3.CataId equals t4.Catagory
                    where t1.Department == subject && t1.Number == num && t2.Semester == season && t2.Year == (uint)year && t3.Name == category
                    select new
                    {
                        aname = t4.Name,
                        cname = t3.Name,
                        due = t4.Due,
                        submissions = 0 // TODO
                    };

                    return Json(assigns.ToArray());

                }


                // int submissions = assigns.Count();

                // assigns.Append(submissions.ToString());



            }



        }


        /// <summary>
        /// Returns a JSON array of the assignment categories for a certain class.
        /// Each object in the array should have the folling fields:
        /// "name" - The category name
        /// "weight" - The category weight
        /// </summary>
        /// <param name="subject">The course subject abbreviation</param>
        /// <param name="num">The course number</param>
        /// <param name="season">The season part of the semester for the class the assignment belongs to</param>
        /// <param name="year">The year part of the semester for the class the assignment belongs to</param>
        /// <param name="category">The name of the assignment category in the class</param>
        /// <returns>The JSON array</returns>
        public IActionResult GetAssignmentCategories(string subject, int num, string season, int year)
        {

            using (Team94LMSContext db = new Team94LMSContext())
            {
                var catagory =
                    from t1 in db.Courses
                    join t2 in db.Classes
                    on t1.CourseId equals t2.Course
                    join t3 in db.AssignmentCatagories
                    on t2.ClassId equals t3.Class
                    where t1.Department == subject && t1.Number == num && t2.Semester == season && t2.Year == (uint)year
                    select new
                    {
                        name = t3.Name,
                        weight = t3.Weight
                    };

                return Json(catagory.ToArray());


            }
        }

        /// <summary>
        /// Creates a new assignment category for the specified class.
        /// </summary>
        /// <param name="subject">The course subject abbreviation</param>
        /// <param name="num">The course number</param>
        /// <param name="season">The season part of the semester for the class the assignment belongs to</param>
        /// <param name="year">The year part of the semester for the class the assignment belongs to</param>
        /// <param name="category">The new category name</param>
        /// <param name="catweight">The new category weight</param>
        /// <returns>A JSON object containing {success = true/false},
        ///	false if an assignment category with the same name already exists in the same class.</returns>
        public IActionResult CreateAssignmentCategory(string subject, int num, string season, int year, string category, int catweight)
        {

            return Json(new { success = false });
        }

        /// <summary>
        /// Creates a new assignment for the given class and category.
        /// </summary>
        /// <param name="subject">The course subject abbreviation</param>
        /// <param name="num">The course number</param>
        /// <param name="season">The season part of the semester for the class the assignment belongs to</param>
        /// <param name="year">The year part of the semester for the class the assignment belongs to</param>
        /// <param name="category">The name of the assignment category in the class</param>
        /// <param name="asgname">The new assignment name</param>
        /// <param name="asgpoints">The max point value for the new assignment</param>
        /// <param name="asgdue">The due DateTime for the new assignment</param>
        /// <param name="asgcontents">The contents of the new assignment</param>
        /// <returns>A JSON object containing success = true/false,
        /// false if an assignment with the same name already exists in the same assignment category.</returns>
        public IActionResult CreateAssignment(string subject, int num, string season, int year, string category, string asgname, int asgpoints, DateTime asgdue, string asgcontents)
        {

            using (Team94LMSContext db = new Team94LMSContext())
            {
                try
                {
                    var catIDs = 
                        from t1 in db.Courses
                        where t1.Department == subject && t1.Number == num
                        join t2 in db.Classes
                        on t1.CourseId equals t2.Course
                        where t2.Semester == season && t2.Year == (uint)year
                        join t3 in db.AssignmentCatagories
                        on t2.ClassId equals t3.Class
                        join t4 in db.Assignments
                        on t3.CataId equals t4.Catagory
                        where t3.Name == category
                        select t4.Catagory;


                    Assignments newAsign = new Assignments();
                    newAsign.Points = (uint)asgpoints;
                    newAsign.Due = asgdue;
                    newAsign.Content = asgcontents;
                    newAsign.Catagory = catIDs.Single();
                    newAsign.Name = asgname;
                   
                    db.Assignments.Add(newAsign);
                    db.SaveChanges();
                    return Json(new { success = true });
                }
                catch (Exception)
                {
                    return Json(new { success = false });
                }
            }



        }


        /// <summary>
        /// Gets a JSON array of all the submissions to a certain assignment.
        /// Each object in the array should have the following fields:
        /// "fname" - first name
        /// "lname" - last name
        /// "uid" - user ID
        /// "time" - DateTime of the submission
        /// "score" - The score given to the submission
        /// 
        /// </summary>
        /// <param name="subject">The course subject abbreviation</param>
        /// <param name="num">The course number</param>
        /// <param name="season">The season part of the semester for the class the assignment belongs to</param>
        /// <param name="year">The year part of the semester for the class the assignment belongs to</param>
        /// <param name="category">The name of the assignment category in the class</param>
        /// <param name="asgname">The name of the assignment</param>
        /// <returns>The JSON array</returns>
        public IActionResult GetSubmissionsToAssignment(string subject, int num, string season, int year, string category, string asgname)
        {

            using (Team94LMSContext db = new Team94LMSContext())
            {
                var submissions =
                    from t1 in db.Courses
                    join t2 in db.Classes
                    on t1.CourseId equals t2.Course
                    join t3 in db.AssignmentCatagories
                    on t2.ClassId equals t3.Class
                    join t4 in db.Assignments
                    on t3.CataId equals t4.Catagory
                    join t5 in db.Submissions
                    on t4.AssignId equals t5.Assignment
                    join t6 in db.Students
                    on t5.Student equals t6.UId
                    where t1.Department == subject && t1.Number == num && t2.Semester == season && t2.Year == year && t3.Name == category && t4.Name == asgname
                    select new
                    {
                        fname = t6.FirstName,
                        lname = t6.LastName,
                        uid = t6.UId,
                        time = t5.Time,
                        score = t5.Score

                    };

                return Json(submissions.ToArray());
            }
        }


        /// <summary>
        /// Set the score of an assignment submission
        /// </summary>
        /// <param name="subject">The course subject abbreviation</param>
        /// <param name="num">The course number</param>
        /// <param name="season">The season part of the semester for the class the assignment belongs to</param>
        /// <param name="year">The year part of the semester for the class the assignment belongs to</param>
        /// <param name="category">The name of the assignment category in the class</param>
        /// <param name="asgname">The name of the assignment</param>
        /// <param name="uid">The uid of the student who's submission is being graded</param>
        /// <param name="score">The new score for the submission</param>
        /// <returns>A JSON object containing success = true/false</returns>
        public IActionResult GradeSubmission(string subject, int num, string season, int year, string category, string asgname, string uid, int score)
        {

            return Json(new { success = true });
        }


        /// <summary>
        /// Returns a JSON array of the classes taught by the specified professor
        /// Each object in the array should have the following fields:
        /// "subject" - The subject abbreviation of the class (such as "CS")
        /// "number" - The course number (such as 5530)
        /// "name" - The course name
        /// "season" - The season part of the semester in which the class is taught
        /// "year" - The year part of the semester in which the class is taught
        /// </summary>
        /// <param name="uid">The professor's uid</param>
        /// <returns>The JSON array</returns>
        public IActionResult GetMyClasses(string uid)
        {

            using (Team94LMSContext db = new Team94LMSContext())
            {
                var classes =
                    from t1 in db.Courses
                    join t2 in db.Classes
                    on t1.CourseId equals t2.Course
                    where t2.Prof == uid
                    select new
                    {
                        subject = t1.Department,
                        number = t1.Number,
                        name = t1.Name,
                        season = t2.Semester,
                        year = t2.Year
                    };

                return Json(classes.ToArray());
            }


        }


        /*******End code to modify********/

    }
}
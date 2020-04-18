using System;
using System.Collections.Generic;

namespace LMS.Models.LMSModels
{
    public partial class Classes
    {
        public Classes()
        {
            AssignmentCatagories = new HashSet<AssignmentCatagories>();
            Enrollment = new HashSet<Enrollment>();
        }

        public uint ClassId { get; set; }
        public uint Course { get; set; }
        public uint Year { get; set; }
        public string Semester { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string Loc { get; set; }
        public string Prof { get; set; }

        public virtual Courses CourseNavigation { get; set; }
        public virtual Professors ProfNavigation { get; set; }
        public virtual ICollection<AssignmentCatagories> AssignmentCatagories { get; set; }
        public virtual ICollection<Enrollment> Enrollment { get; set; }
    }
}

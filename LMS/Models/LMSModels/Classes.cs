using System;
using System.Collections.Generic;

namespace LMS.Models.LMSModels
{
    public partial class Classes
    {
        public Classes()
        {
            AssignmentCatagories = new HashSet<AssignmentCatagories>();
        }

        public uint ClassId { get; set; }
        public uint Course { get; set; }
        public uint Year { get; set; }
        public string Semester { get; set; }
        public TimeSpan Start { get; set; }
        public TimeSpan End { get; set; }
        public string Loc { get; set; }
        public string Prof { get; set; }

        public virtual Courses CourseNavigation { get; set; }
        public virtual Professors ProfNavigation { get; set; }
        public virtual ICollection<AssignmentCatagories> AssignmentCatagories { get; set; }
    }
}

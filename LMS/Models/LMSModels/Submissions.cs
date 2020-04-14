using System;
using System.Collections.Generic;

namespace LMS.Models.LMSModels
{
    public partial class Submissions
    {
        public string Student { get; set; }
        public uint Assignment { get; set; }
        public string Content { get; set; }
        public DateTime Time { get; set; }
        public uint Score { get; set; }

        public virtual Assignments AssignmentNavigation { get; set; }
        public virtual Students StudentNavigation { get; set; }
    }
}

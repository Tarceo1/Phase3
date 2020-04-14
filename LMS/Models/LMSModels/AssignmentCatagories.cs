using System;
using System.Collections.Generic;

namespace LMS.Models.LMSModels
{
    public partial class AssignmentCatagories
    {
        public AssignmentCatagories()
        {
            Assignments = new HashSet<Assignments>();
        }

        public uint CataId { get; set; }
        public uint Class { get; set; }
        public string Name { get; set; }
        public uint Weight { get; set; }

        public virtual Classes ClassNavigation { get; set; }
        public virtual ICollection<Assignments> Assignments { get; set; }
    }
}

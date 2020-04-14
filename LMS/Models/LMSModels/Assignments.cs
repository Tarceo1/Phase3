using System;
using System.Collections.Generic;

namespace LMS.Models.LMSModels
{
    public partial class Assignments
    {
        public Assignments()
        {
            Submissions = new HashSet<Submissions>();
        }

        public uint AssignId { get; set; }
        public uint Catagory { get; set; }
        public string Name { get; set; }
        public uint Points { get; set; }
        public string Content { get; set; }
        public DateTime Due { get; set; }

        public virtual AssignmentCatagories CatagoryNavigation { get; set; }
        public virtual ICollection<Submissions> Submissions { get; set; }
    }
}

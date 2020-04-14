using System;
using System.Collections.Generic;

namespace LMS.Models.LMSModels
{
    public partial class Enrollment
    {
        public string Student { get; set; }
        public uint Class { get; set; }
        public string Grade { get; set; }
    }
}

using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace University.Models
{
    public partial class StudyGroup
    {
        public StudyGroup()
        {
            EntryInStudyStatement = new HashSet<EntryInStudyStatement>();
            Gradebook = new HashSet<Gradebook>();
        }

        public int GroupPk { get; set; }
        public string Number { get; set; }
        public int StudyPlanPk { get; set; }
        public int SpecialityPk { get; set; }

        public virtual StudyPlan S { get; set; }
        public virtual ICollection<EntryInStudyStatement> EntryInStudyStatement { get; set; }
        public virtual ICollection<Gradebook> Gradebook { get; set; }
    }
}

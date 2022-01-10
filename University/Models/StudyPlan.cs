using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace University.Models
{
    public partial class StudyPlan
    {
        public StudyPlan()
        {
            EntryInStudyPlan = new HashSet<EntryInStudyPlan>();
            StudyGroup = new HashSet<StudyGroup>();
        }

        public int StudyPlanPk { get; set; }
        public int SpecialityPk { get; set; }
        public string PlanNumber { get; set; }

        public virtual Speciality SpecialityPkNavigation { get; set; }
        public virtual ICollection<EntryInStudyPlan> EntryInStudyPlan { get; set; }
        public virtual ICollection<StudyGroup> StudyGroup { get; set; }
    }
}

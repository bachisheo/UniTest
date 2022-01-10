using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace University.Models
{
    public partial class EntryInStudyPlan
    {
        public int EntryInStudyPlanPk { get; set; }
        public int StudyPlanPk { get; set; }
        public int SpecialityPk { get; set; }
        public int DisciplinePk { get; set; }

        public virtual Discipline DisciplinePkNavigation { get; set; }
        public virtual StudyPlan S { get; set; }
    }
}

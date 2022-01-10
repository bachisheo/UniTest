using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace University.Models
{
    public partial class StudyStatementHeader
    {
        public StudyStatementHeader()
        {
            EntryInStudyStatement = new HashSet<EntryInStudyStatement>();
        }

        public int StudyStatementHeaderPk { get; set; }
        public int TeacherPk { get; set; }
        public int DepartmentPk { get; set; }

        public virtual Department DepartmentPkNavigation { get; set; }
        public virtual Teacher TeacherPkNavigation { get; set; }
        public virtual ICollection<EntryInStudyStatement> EntryInStudyStatement { get; set; }
    }
}

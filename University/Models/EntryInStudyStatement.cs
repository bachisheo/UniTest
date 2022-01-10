using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace University.Models
{
    public partial class EntryInStudyStatement
    {
        public EntryInStudyStatement()
        {
            StatementHeader = new HashSet<StatementHeader>();
        }

        public int EntryInStudyStatementPk { get; set; }
        public int DisciplinePk { get; set; }
        public int StudyStatementHeaderPk { get; set; }
        public int? GroupPk { get; set; }

        public virtual Discipline DisciplinePkNavigation { get; set; }
        public virtual StudyGroup GroupPkNavigation { get; set; }
        public virtual StudyStatementHeader StudyStatementHeaderPkNavigation { get; set; }
        public virtual ICollection<StatementHeader> StatementHeader { get; set; }
    }
}

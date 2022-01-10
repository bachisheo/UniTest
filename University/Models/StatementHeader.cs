using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace University.Models
{
    public partial class StatementHeader
    {
        public StatementHeader()
        {
            Result = new HashSet<Result>();
        }

        public int StatementHeaderPk { get; set; }
        public string Number { get; set; }
        public DateTime Data { get; set; }
        public int EntryInStudyStatementPk { get; set; }
        public int StudyStatementHeaderPk { get; set; }

        public virtual EntryInStudyStatement EntryInStudyStatement { get; set; }
        public virtual ICollection<Result> Result { get; set; }
    }
}

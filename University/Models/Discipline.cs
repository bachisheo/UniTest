using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace University.Models
{
    public partial class Discipline
    {
        public Discipline()
        {
            EntryInStudyPlan = new HashSet<EntryInStudyPlan>();
            EntryInStudyStatement = new HashSet<EntryInStudyStatement>();
            Ticket = new HashSet<Ticket>();
            Topic = new HashSet<Topic>();
        }

        public int DisciplinePk { get; set; }
        public string Name { get; set; }

        public virtual ICollection<EntryInStudyPlan> EntryInStudyPlan { get; set; }
        public virtual ICollection<EntryInStudyStatement> EntryInStudyStatement { get; set; }
        public virtual ICollection<Ticket> Ticket { get; set; }
        public virtual ICollection<Topic> Topic { get; set; }
    }
}

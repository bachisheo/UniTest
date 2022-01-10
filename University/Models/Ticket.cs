using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace University.Models
{
    public partial class Ticket
    {
        public Ticket()
        {
            Result = new HashSet<Result>();
            TaskInTest = new HashSet<TaskInTest>();
        }

        public int TicketPk { get; set; }
        public long NumberTick { get; set; }
        public int DisciplinePk { get; set; }

        public virtual Discipline DisciplinePkNavigation { get; set; }
        public virtual ICollection<Result> Result { get; set; }
        public virtual ICollection<TaskInTest> TaskInTest { get; set; }
    }
}

using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace University.Models
{
    public partial class TaskInTest
    {
        public TaskInTest()
        {
            AnswerToTask = new HashSet<AnswerToTask>();
        }

        public int TaskInTestPk { get; set; }
        public int TaskPk { get; set; }
        public int TicketPk { get; set; }

        public virtual Task TaskPkNavigation { get; set; }
        public virtual Ticket TicketPkNavigation { get; set; }
        public virtual ICollection<AnswerToTask> AnswerToTask { get; set; }
    }
}

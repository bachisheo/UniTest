using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace University.Models
{
    public partial class Result
    {
        public Result()
        {
            AnswerToTask = new HashSet<AnswerToTask>();
        }

        public int ResultPk { get; set; }
        public int GradebookPk { get; set; }
        public int StudentPk { get; set; }
        public int TicketPk { get; set; }
        public int StatementHeaderPk { get; set; }
        public int? Grade { get; set; }
        public DateTime Data { get; set; }
        public bool? IsActive { get; set; }

        public virtual Gradebook Gradebook { get; set; }
        public virtual StatementHeader StatementHeaderPkNavigation { get; set; }
        public virtual Ticket TicketPkNavigation { get; set; }
        public virtual ICollection<AnswerToTask> AnswerToTask { get; set; }
    }
}

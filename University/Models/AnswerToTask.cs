using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace University.Models
{
    public partial class AnswerToTask
    {
        public int AnswerPk { get; set; }
        public string Answer { get; set; }
        public int TaskInTestPk { get; set; }
        public int ResultPk { get; set; }
        public int TicketPk { get; set; }

        public virtual Result ResultPkNavigation { get; set; }
        public virtual TaskInTest T { get; set; }
    }
}

using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace University.Models
{
    public partial class Gradebook
    {
        public Gradebook()
        {
            Result = new HashSet<Result>();
        }

        public int GradebookPk { get; set; }
        public string Number { get; set; }
        public int StudentPk { get; set; }
        public int? GroupPk { get; set; }

        public virtual StudyGroup GroupPkNavigation { get; set; }
        public virtual Student StudentPkNavigation { get; set; }
        public virtual ICollection<Result> Result { get; set; }
    }
}
